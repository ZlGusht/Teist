namespace Teist.Web.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Teist.Common.ViewModels;
    using Teist.Data.Managers;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Review/5
        [HttpGet("{id}", Name = "GetReview")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Review
        [HttpPost]
        public void Post([FromBody] ReviewViewModel review)
        {
            this.manager.Create(review, this.User);
        }

        // PUT: api/Review/5
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
