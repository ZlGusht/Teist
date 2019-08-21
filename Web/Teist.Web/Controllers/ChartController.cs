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

        // POST: api/Chart
        [HttpPost]
        public IActionResult Post([FromBody] ChartViewModel chart)
        {
            if (chart == null || !this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            this.manager.Create(chart);
            return Ok();
        }
    }
}
