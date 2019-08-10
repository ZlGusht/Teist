namespace Teist.Web.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Teist.Common.ViewModels;
    using Teist.Data.Managers;
    using Teist.Data.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : BaseController 
    {
        private readonly ChartManager manager;

        public ChartController(ChartManager manager)
        {
            this.manager = manager;
        }

        // GET: api/Chart
        [HttpGet]
        public IEnumerable<Chart> Get()
        {
            return this.manager.All();
        }

        // GET: api/Chart/5
        [HttpGet("{id}", Name = "GetChart")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Chart
        [HttpPost]
        public void Post([FromBody] ChartViewModel chart)
        {
            this.manager.Create(chart);
        }

        // PUT: api/Chart/5
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
