namespace Teist.Data
{
    using System.Security.Claims;

    using Teist.Data.Models;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class ApplicationRoleStore : RoleStore<
        ApplicationRole,
        TeistDbContext,
        string,
        IdentityUserRole<string>,
        IdentityRoleClaim<string>>
    {
        public ApplicationRoleStore(TeistDbContext context, IdentityErrorDescriber describer = null)
            : base(context, describer)
        {
        }

        protected override IdentityRoleClaim<string> CreateRoleClaim(ApplicationRole role, Claim claim) =>
            new IdentityRoleClaim<string>
            {
                RoleId = role.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value,
            };
    }
}
