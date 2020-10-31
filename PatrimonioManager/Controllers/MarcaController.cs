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
        private ApplicationDbContext _context;

        public MarcaController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMarcas(string query = null)
        {
            var marcasQuery = (IEnumerable<Marca>)_context.Marcas;

            if (!String.IsNullOrWhiteSpace(query))
                marcasQuery = marcasQuery.Where(m => m.Nome.Contains(query));

            var marcasDtos = marcasQuery.ToList()
                .Select(Mapper.Map<Marca, MarcaDto>);

            return Ok();
        }


    }
}