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
    public class KategoriasController : ApiController
    {


        private ApplicationDbContext _context;


        public KategoriasController()
        {
            _context = new ApplicationDbContext();
        }


        public IEnumerable<KategoriaDto> GetKategoria()
        {
            return _context.Kategorias.ToList().Select(Mapper.Map<Kategoria, KategoriaDto>);
        }


        public IHttpActionResult GetKategoria(int id)
        {
            var kategoria = _context.Kategorias.SingleOrDefault(c => c.Id == id);


            if (kategoria == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Kategoria, KategoriaDto>(kategoria));

        }


        [HttpPost]
        public IHttpActionResult CreateKategoria(KategoriaDto kategoriaDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var kategoria = Mapper.Map<KategoriaDto, Kategoria>(kategoriaDto);
            _context.Kategorias.Add(kategoria);
            _context.SaveChanges();

            kategoriaDto.Id = kategoria.Id;
            return Created(new Uri(Request.RequestUri + "/" + kategoria.Id), kategoriaDto);
        }



        [HttpPut]
        public void UpdateKategoria(int id, KategoriaDto kategoriaDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var kategoriaInDb = _context.Kategorias.SingleOrDefault(c => c.Id == id);

            if (kategoriaInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(kategoriaDto, kategoriaDto);


            _context.SaveChanges();

        }


        [HttpDelete]
        public void DeleteKategoria(int id)
        {
            var kategoriaInDb = _context.Kategorias.SingleOrDefault(c => c.Id == id);

            if (kategoriaInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }


            _context.Kategorias.Remove(kategoriaInDb);
            _context.SaveChanges();

        }




    }





}
