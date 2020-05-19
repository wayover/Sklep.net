using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using WebApplication3.Dtos;
using WebApplication3.Models;

namespace WebApplication3.Controllers.Api
{
    public class ProducentsController : ApiController
    {

        private ApplicationDbContext _context;


        public ProducentsController()
        {
            _context = new ApplicationDbContext();
        }


        public IEnumerable<ProducentDto> GetProducent()
        {
            return _context.Producents.ToList().Select(Mapper.Map<Producent, ProducentDto>);
        }


        public IHttpActionResult GetProducent(int id)
        {
            var producent = _context.Producents.SingleOrDefault(c => c.Id == id);


            if (producent == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Producent, ProducentDto>(producent));

        }


        [HttpPost]
        public IHttpActionResult CreateProducent(ProducentDto producentDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var producent = Mapper.Map<ProducentDto, Producent>(producentDto);
            _context.Producents.Add(producent);
            _context.SaveChanges();

            producentDto.Id = producent.Id;
            return Created(new Uri(Request.RequestUri + "/" + producent.Id), producentDto);
        }



        [HttpPut]
        public void UpdateProducent(int id, ProducentDto producentDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var producentInDb = _context.Producents.SingleOrDefault(c => c.Id == id);

            if (producentInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(producentDto, producentInDb);


            _context.SaveChanges();

        }


        [HttpDelete]
        public void DeleteProducent(int id)
        {
            var producentInDb = _context.Producents.SingleOrDefault(c => c.Id == id);

            if (producentInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }


            _context.Producents.Remove(producentInDb);
            _context.SaveChanges();

        }




    }
}
