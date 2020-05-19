using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using WebApplication3.Dtos;
using WebApplication3.Models;
using System.Data.Entity;

namespace WebApplication3.Controllers.Api
{
    public class PrzedmiotsController : ApiController
    {

        private ApplicationDbContext _context;


        public PrzedmiotsController()
        {
            _context = new ApplicationDbContext();
        }


        public IHttpActionResult GetPrzedmiots()
        {
            var przedmiotDtos= _context.Przedmiots
                .Include(c=>c.Kategoria)
                .Include(c=>c.Producent)
                .ToList().Select(Mapper.Map<Przedmiot,PrzedmiotDto>);
            return Ok(przedmiotDtos);
        }


        public IHttpActionResult GetPrzedmiot(int id)
        {
            var przedmiot = _context.Przedmiots.SingleOrDefault(c => c.ID == id);


            if (przedmiot == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Przedmiot,PrzedmiotDto>(przedmiot));

        }


        [HttpPost]
        public IHttpActionResult CreatePrzedmiot(PrzedmiotDto przedmiotDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var przedmiot = Mapper.Map<PrzedmiotDto, Przedmiot>(przedmiotDto);
            _context.Przedmiots.Add(przedmiot);
            _context.SaveChanges();

            przedmiotDto.ID = przedmiot.ID;
            return Created(new Uri(Request.RequestUri +"/"+ przedmiot.ID), przedmiotDto);
        }



        [HttpPut]
        public IHttpActionResult UpdatePrzedmiot(int id, PrzedmiotDto przedmiotDto)
        {
            if (!ModelState.IsValid)
            {
               return BadRequest();
            }

            var przedmiotInDb = _context.Przedmiots.SingleOrDefault(c => c.ID == id);

            if(przedmiotInDb==null)
            {
                return NotFound();
            }
            Mapper.Map(przedmiotDto, przedmiotInDb);


            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult DeletePrzedmiot(int id)
        {
            var przedmiotInDb = _context.Przedmiots.SingleOrDefault(c => c.ID == id);

            if (przedmiotInDb == null)
            {
                return NotFound();
            }


            _context.Przedmiots.Remove(przedmiotInDb);
            _context.SaveChanges();

            return Ok();
        }


    }
}
