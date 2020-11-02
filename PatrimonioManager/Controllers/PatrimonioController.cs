using PatrimonioManager.Models;
using PatrimonioManager.Dtos;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using AutoMapper;
using System.Web.Http.Results;
using PatrimonioManager.Helpers;

namespace PatrimonioManager.Controllers
{    
    public class PatrimonioController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public PatrimonioController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        // GET api/Patrimonio or api/Patrimonio?query={ query }        
        public IHttpActionResult GetPatrimonios(string query = null)
        {
            var patrimoniosQuery = _context.Patrimonios.Include(p => p.Marca);

            if (!string.IsNullOrEmpty(query))
                patrimoniosQuery = patrimoniosQuery.Where(p => p.Nome.Contains(query));

            var patrimoniosDtos = patrimoniosQuery.ToList()
                .Select(Mapper.Map<Patrimonio, PatrimonioDtoOut>);

            return Ok(patrimoniosDtos);
        }

        [Authorize]
        // GET api/Patrimonio/{id}        
        public IHttpActionResult GetPatrimonio(int id)
        {
            var patrimonio = _context.Patrimonios.SingleOrDefault(p => p.Id == id);

            if (patrimonio == null)
                return NotFound();

            var patrimonioDto = Mapper.Map<Patrimonio, PatrimonioDtoOut>(patrimonio);

            return Ok(patrimonioDto);
        }

        [HttpPost]
        [Authorize]
        // POST api/Patrimonio
        public IHttpActionResult CreatePatrimonio(PatrimonioDtoIn patrimonioDtoIn)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!IsMarcaInDatabase(patrimonioDtoIn.MarcaId))
                return BadRequest(ResultMessageHelper.MarcaNotFoundMessage(patrimonioDtoIn.MarcaId));

            var patrimonio = Mapper.Map<PatrimonioDtoIn, Patrimonio>(patrimonioDtoIn);

            _context.Patrimonios.Add(patrimonio);
            _context.SaveChanges();

            var patrimonioDtoOut = Mapper.Map<Patrimonio, PatrimonioDtoOut>(patrimonio);
            
            return Ok(patrimonioDtoOut);
        }

        [HttpPut]
        [Authorize]
        // PUT api/Patrimonio/{id}
        public IHttpActionResult UpdatePatrimonio(int id, PatrimonioDtoIn patrimonioDtoIn)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!IsMarcaInDatabase(patrimonioDtoIn.MarcaId))
                return BadRequest(ResultMessageHelper.MarcaNotFoundMessage(patrimonioDtoIn.MarcaId));

           if (!IsPatrimonioInDatabase(id, out Patrimonio patrimonioInDb))
                return NotFound();

            Mapper.Map(patrimonioDtoIn, patrimonioInDb);

            _context.SaveChanges();

            var patrimonioDtoOut = Mapper.Map<Patrimonio, PatrimonioDtoOut>(patrimonioInDb);

            return Ok(patrimonioDtoOut);
        }

        [HttpDelete]
        [Authorize]
        // DELETE api/Patrimonio/{id}
        public IHttpActionResult DeletePatrimonio(int id)
        {
           if (!IsPatrimonioInDatabase(id, out Patrimonio patrimonioInDb))                
                return NotFound();

            _context.Patrimonios.Remove(patrimonioInDb);
            _context.SaveChanges();

            return Ok();
        }

        public bool IsMarcaInDatabase(int id)
        {
            var queryMarcaInDb = _context.Marcas.SingleOrDefault(m => m.Id == id);

            if (queryMarcaInDb == null)
                return false;

            return true;
        }

        public bool IsPatrimonioInDatabase(int id, out Patrimonio patrimonioInDb)
        {
            patrimonioInDb = _context.Patrimonios.SingleOrDefault(p => p.Id == id);

            if (patrimonioInDb == null)
                return false;

            return true;
        }
    }
}