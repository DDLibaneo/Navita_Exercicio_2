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

namespace PatrimonioManager.Controllers
{
    public class PatrimonioController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public PatrimonioController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetPatrimonios(string query = null)
        {
            var patrimoniosQuery = _context.Patrimonios.Include(p => p.Marca);

            if (string.IsNullOrEmpty(query))
                patrimoniosQuery = patrimoniosQuery.Where(p => p.Nome.Contains(query));

            var patrimoniosDtos = patrimoniosQuery.ToList()
                .Select(Mapper.Map<Patrimonio, PatrimonioDto>);

            return Ok(patrimoniosDtos);
        }

        public IHttpActionResult GetPatrimonio(int id)
        {
            var patrimonio = _context.Patrimonios.SingleOrDefault(p => p.Id == id);

            if (patrimonio == null)
                return NotFound();

            var patrimonioDto = Mapper.Map<Patrimonio, PatrimonioDto>(patrimonio);

            return Ok(patrimonioDto);
        }

        [HttpPost]
        public IHttpActionResult CreatePatrimonio(PatrimonioDto patrimonioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var patrimonio = Mapper.Map<PatrimonioDto, Patrimonio>(patrimonioDto);

            _context.Patrimonios.Add(patrimonio);
            _context.SaveChanges();

            patrimonioDto.Id = patrimonio.Id;

            return Ok(patrimonioDto);
        }

        [HttpPut]
        public IHttpActionResult UpdatePatrimonio(int id, PatrimonioDto patrimonioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var patrimonioInDb = _context.Patrimonios.SingleOrDefault(p => p.Id == id);

            if (patrimonioInDb == null)
                return NotFound();

            Mapper.Map(patrimonioDto, patrimonioInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeletePatrimonio(int id)
        {
            var patrimonioInDb = _context.Patrimonios.SingleOrDefault(p => p.Id == id);

            if (patrimonioInDb == null)
                return NotFound();

            _context.Patrimonios.Remove(patrimonioInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}