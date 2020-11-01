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

            if (!String.IsNullOrWhiteSpace(query))
                marcasQuery = marcasQuery.Where(m => m.Nome.Contains(query));

            var marcasDtos = marcasQuery.ToList()
                .Select(Mapper.Map<Marca, MarcaDto>);

            return Ok(marcasDtos);
        }

        // GET /api/marcas/{id}
        public IHttpActionResult GetMarca(int id)
        {
            var marca = _context.Marcas.SingleOrDefault(m => m.Id == id);

            if (marca == null)
                return NotFound();

            var marcaDto = Mapper.Map<Marca, MarcaDto>(marca);

            return Ok(marcaDto);
        }

        // POST /api/marca
        [HttpPost]
        public IHttpActionResult CreateMarca(MarcaDto marcaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var marca = Mapper.Map<MarcaDto, Marca>(marcaDto);

            _context.Marcas.Add(marca);
            _context.SaveChanges();

            marcaDto.Id = marca.Id;

            return Ok(marcaDto);
        }

        // PUT /api/marca/{id}
        [HttpPut]
        public IHttpActionResult UpdateMarca(int id, MarcaDto marcaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var marcaInDb = _context.Marcas.SingleOrDefault(m => m.Id == id);

            if (marcaInDb == null)
                return NotFound();

            Mapper.Map(marcaDto, marcaInDb);

            _context.SaveChanges();

            return Ok();
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