using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teist.Common.ViewModels;
using Teist.Data.Managers;
using Teist.Data.Models;

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

        // GET: api/Piece/5
        [HttpGet("{name}", Name = "GetPiece")]
        public Piece Get(string name)
        {
            return null;
        }

        // POST: api/Piece
        [HttpPost]
        public void Post([FromBody] PieceViewModel piece)
        {
            this.manager.Create(piece);
        }

        // PUT: api/Piece/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] PieceViewModel piece)
        {
            this.manager.Update(id, piece);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            this.manager.Delete(id);
        }
    }
}
