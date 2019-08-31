using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teist.Common.ViewModels;
using Teist.Data.Models;
using Teist.Services;

namespace Teist.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PieceController : BaseController
    {
        private readonly PieceManager manager;

        public PieceController(PieceManager manager)
        {
            this.manager = manager;
        }

        // GET: api/Piece
        [HttpGet]
        public IEnumerable<Piece> Get()
        {
            return this.manager.GetAll();
        }

        // POST: api/Piece
        [HttpPost]
        public IActionResult Post([FromBody] PieceViewModel piece)
        {
            if (piece == null || !this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            this.manager.Create(piece);

            return this.Ok();
        }

        // PUT: api/Piece/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] PieceViewModel piece)
        {
            if (id == null || piece == null || !this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            this.manager.Update(id, piece);

            return this.Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            this.manager.Delete(id);
        }
    }
}
