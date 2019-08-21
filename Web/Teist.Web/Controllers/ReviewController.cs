namespace Teist.Web.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Teist.Common.ViewModels;
    using Teist.Data.Managers;
    using Teist.Data.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : BaseController
    {
        private readonly ReviewManager manager;

        public ReviewController(ReviewManager manager)
        {
            this.manager = manager;
        }

        // GET: api/Review
        [HttpGet]
        public IEnumerable<Review> Get()
        {
            return this.manager.All();
        }

        // POST: api/Review
        [HttpPost]
        public IActionResult Post([FromBody] ReviewViewModel review)
        {
            if (review == null || !this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            this.manager.Create(review, this.User);

            return this.Ok();
        }
    }
}
