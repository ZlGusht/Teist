namespace Teist.Web
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using Newtonsoft.Json;
    using Teist.Common;
    using Teist.Common.Mapping;
    using Teist.Data;
    using Teist.Data.Common.Repositories;
    using Teist.Data.Managers;
    using Teist.Data.Models;
    using Teist.Data.Repositories;
    using Teist.Data.Seeding;
    using Teist.Services.Messaging;
    using Teist.Web.Infrastructure.Middlewares.Auth;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Framework services
            // TODO: Add pooling when this bug is fixed: https://github.com/aspnet/EntityFrameworkCore/issues/9741
            services.AddDbContext<TeistDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies());

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["JwtTokenValidation:Secret"]));

            services.Configure<TokenProviderOptions>(opts =>
            {
                opts.Audience = this.configuration["JwtTokenValidation:Audience"];
                opts.Issuer = this.configuration["JwtTokenValidation:Issuer"];
                opts.Path = "/api/Account/Login";
                opts.Expiration = TimeSpan.FromDays(15);
                opts.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });

            services
                .AddAuthentication()
                .AddJwtBearer(opts =>
                {
                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,
                        ValidateIssuer = true,
                        ValidIssuer = this.configuration["JwtTokenValidation:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = this.configuration["JwtTokenValidation:Audience"],
                        ValidateLifetime = true,
                    };
                });

            services
                .AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<TeistDbContext>()
                .AddUserStore<ApplicationUserStore>()
                .AddRoleStore<ApplicationRoleStore>()
                .AddDefaultTokenProviders();

            services.AddLogging(builder =>
            {
                builder.AddDebug();
            });

            services.AddCors();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(x =>
                {
                    x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                }); 

            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(AlbumRepository));
            services.AddScoped(typeof(ArtistRepository));
            services.AddScoped(typeof(ChartRepository));
            services.AddScoped(typeof(PieceRepository));
            services.AddScoped(typeof(ReviewRepository));
            services.AddScoped(typeof(UserRepository));

            // Managers
            services.AddScoped(typeof(AlbumManager));
            services.AddScoped(typeof(ArtistManager));
            services.AddScoped(typeof(ChartManager));
            services.AddScoped(typeof(PieceManager));
            services.AddScoped(typeof(ReviewManager));


            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<ISmsSender, NullMessageSender>();

            // Identity stores
            services.AddTransient<IUserStore<ApplicationUser>, ApplicationUserStore>();
            services.AddTransient<IRoleStore<ApplicationRole>, ApplicationRoleStore>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //AutoMapperConfig.RegisterMappings(typeof(TodoItemViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<TeistDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                TeistDbContextSeeder.Seed(dbContext, serviceScope.ServiceProvider);
            }

            if (env.IsDevelopment())
            {
                app.UseExceptionHandler(application =>
                {
                    application.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = GlobalConstants.JsonContentType;
                        var buffer = new byte[10000];
                        var body = context.Request.Body.Read(buffer);

                        var ex = context.Features.Get<IExceptionHandlerFeature>();
                        if (ex != null)
                        {
                            await context.Response
                                .WriteAsync(JsonConvert.SerializeObject(new { ex.Error?.Message, ex.Error?.StackTrace }))
                                .ConfigureAwait(continueOnCapturedContext: false);
                        }
                    });
                });
            }

            app.UseFileServer();

            app.UseCors(options =>
            {


                options.AllowAnyHeader();

                options.AllowAnyMethod();


                options.WithOrigins("http://localhost:4200");


            });

            app.UseJwtBearerTokens(app.ApplicationServices.GetRequiredService<IOptions<TokenProviderOptions>>(), PrincipalResolver);

            app.UseMvc(routes => routes.MapRoute("default", "api/{controller}/{action}/{id?}"));
        }

        private static async Task<GenericPrincipal> PrincipalResolver(HttpContext context)
        {
            var email = context.Request.Form["Email"];

            var userManager = context.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
            var user = await userManager.FindByEmailAsync(email);
            if (user == null || user.IsDeleted)
            {
                return null;
            }

            var password = context.Request.Form["Password"];

            var isValidPassword = await userManager.CheckPasswordAsync(user, password);
            if (!isValidPassword)
            {
                return null;
            }

            var roles = await userManager.GetRolesAsync(user);

            var identity = new GenericIdentity(email, "Token");
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
            identity.AddClaim(new Claim("Roles", string.Join(", ", roles)));

            return new GenericPrincipal(identity, roles.ToArray());
        }
    }
}
