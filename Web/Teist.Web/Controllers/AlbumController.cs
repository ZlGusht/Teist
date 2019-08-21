namespace Teist.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Teist.Common.ViewModels;
    using Teist.Data.Managers;

    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : BaseController
    {
        private readonly AlbumManager manager;

        public AlbumController(AlbumManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return this.Ok(this.manager.GetAll());
        }

        [HttpGet("{name}", Name = "GetAlbum")]
        public IActionResult Get(string name)
        {
            return this.Ok(this.manager.Get(name));
        }

        [HttpPost]
        public IActionResult Post([FromBody] AlbumViewModel album)
        {
            if (album == null || !this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            this.manager.CreateAlbum(album);
            return this.Ok();
        }

        [HttpPut]
        public IActionResult Put(string name, [FromBody] AlbumViewModel album)
        {
            if (name == null || album == null || !this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var old = this.manager.Get(name);

            this.manager.Update(old, album);

            return this.Ok();

        }

        [HttpDelete]
        public void Delete(string name)
        {
            this.manager.Delete(name);
        }
    }
}
