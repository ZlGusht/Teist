namespace Teist.Web.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Teist.Common.ViewModels;
    using Teist.Data.Models;
    using Teist.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : BaseController
    {
        private readonly ArtistManager manager;

        public ArtistController(ArtistManager manager)
        {
            this.manager = manager;
        }

        // GET: api/Artist
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return this.manager.GetAll();
        }

        // POST: api/Artist
        [HttpPost]
        public IActionResult Post([FromBody] ArtistViewModel artist)
        {
            if (artist == null || !this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            this.manager.Create(artist);

            return this.Ok();
        }
    }
}
