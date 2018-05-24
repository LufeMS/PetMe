using AutoMapper;
using PetMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetMe.Controllers.Api
{
    public class PetsController : ApiController
    {
        ApplicationDbContext db;

        public PetsController()
        {
            db = new ApplicationDbContext();
        }

        //get api/pets
        [HttpGet]
        public IHttpActionResult GetPets(string search = null)
        {
            var petsQuery = db.Pets;

            if (search != null)
            {

            }

            var pets = petsQuery;

            return Ok(pets);
        }

        //get api/pets/1
        [HttpGet]
        public IHttpActionResult GetPets(int id)
        {
            var pet = db.Pets.Find(id);

            if (pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
        }

        //post api/pets
        [HttpPost]
        public IHttpActionResult CreatePet(Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            pet.Active = true;
            pet.AddedIn = DateTime.Now;

            db.Pets.Add(pet);
            db.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + pet.Id), pet);
        }

        //put api/pet/1
        [HttpPut]
        public IHttpActionResult UpdatePet(int id, Pet pet)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var petInDb = db.Pets.Find(id);

            if (petInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Mapper.Map(pet, petInDb);

            db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeletePet(int id)
        {
            var petInBd = db.Pets.Find(id);

            if (petInBd == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            petInBd.Active = false;

            db.SaveChanges();

            return Ok();
        }
    }
}
