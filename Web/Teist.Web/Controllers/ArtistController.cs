namespace Teist.Web.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Teist.Common.ViewModels;
    using Teist.Data.Managers;
    using Teist.Data.Models;

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

        // GET: api/Artist/5
        [HttpGet("{name}", Name = "GetArtist")]
        public Artist Get(string name)
        {
            return null;
        }

        // POST: api/Artist
        [HttpPost]
        public IActionResult Post([FromBody] ArtistViewModel artist)
        {
            if (artist == null)
            {
                return this.BadRequest();
            }

            this.manager.Create(artist);

            return this.Ok();
        }

        // PUT: api/Artist/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
