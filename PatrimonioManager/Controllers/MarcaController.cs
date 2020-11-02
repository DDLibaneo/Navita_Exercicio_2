using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.Entity;
using PatrimonioManager.Models;
using AutoMapper;
using PatrimonioManager.Dtos;

namespace PatrimonioManager.Controllers
{
    public class MarcaController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MarcaController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/marca or /api/Marca?query={query}
        public IHttpActionResult GetMarcas(string query = null)
        {
            var marcasQuery = (IEnumerable<Marca>)_context.Marcas;

            if (!string.IsNullOrWhiteSpace(query))
                marcasQuery = marcasQuery.Where(m => m.Nome.Contains(query));

            var marcasDtos = marcasQuery.ToList()
                .Select(Mapper.Map<Marca, MarcaDtoOut>);

            return Ok(marcasDtos);
        }

        // GET /api/marcas/{id}
        public IHttpActionResult GetMarca(int id)
        {
            var marca = _context.Marcas.SingleOrDefault(m => m.Id == id);

            if (marca == null)
                return NotFound();

            var marcaDto = Mapper.Map<Marca, MarcaDtoOut>(marca);

            return Ok(marcaDto);
        }

        // POST /api/marca
        [HttpPost]
        public IHttpActionResult CreateMarca(MarcaDtoIn marcaDtoIn)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var queryMarcasInDb = _context.Marcas
                .Where(m => m.Nome.ToUpper() == marcaDtoIn.Nome.ToUpper());

            if (queryMarcasInDb.Count() > 0)
                return BadRequest($"Marca {marcaDtoIn.Nome} já existe no banco de dados.");

            var marca = Mapper.Map<MarcaDtoIn, Marca>(marcaDtoIn);

            _context.Marcas.Add(marca);
            _context.SaveChanges();

            var marcaDtoOut = Mapper.Map<Marca, MarcaDtoOut>(marca);

            return Ok(marcaDtoOut);
        }

        // PUT /api/marca/{id}
        [HttpPut]
        public IHttpActionResult UpdateMarca(int id, MarcaDtoIn marcaDtoIn)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var marcaInDb = _context.Marcas.SingleOrDefault(m => m.Id == id);

            if (marcaInDb == null)
                return NotFound();

            Mapper.Map(marcaDtoIn, marcaInDb);

            _context.SaveChanges();

            var marcaDtoOut = Mapper.Map<Marca, MarcaDtoOut>(marcaInDb);

            return Ok(marcaDtoOut);
        }

        // DELETE /api/marca/{id}
        [HttpDelete]
        public IHttpActionResult DeleteMarca(int id)
        {
            var marcaInDb = _context.Marcas.SingleOrDefault(m => m.Id == id);

            if (marcaInDb == null)
                return NotFound();

            _context.Marcas.Remove(marcaInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}