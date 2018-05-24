using AutoMapper;
using Microsoft.AspNet.Identity;
using PetMe.Models;
using PetMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetMe.Controllers
{
    public class PetsController : Controller
    {
        ApplicationDbContext db;

        public PetsController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult PetList(string id)
        {
            if (id == null)
                id = User.Identity.GetUserId();

            var user = db.Users.Find(id);

            if (user == null)
            {
                return View("Login");
            }

            var pets = db.Pets.Where(p => p.OwnerId == id).ToList();

            var petViewModel = new PetListViewModel
            {
                User = user,
                Pets = pets
            };

            return View(petViewModel);
        }

        public ActionResult PetForm(int? id)
        {
            Pet pet;

            if (id == null)
            {
                pet = new Pet
                {
                    Id = 0,
                    OwnerId = User.Identity.GetUserId()
                };
                return View(pet);
            }

            pet = db.Pets.Find(id);

            return View(pet);
        }

        public ActionResult SalvarPet(Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return View("PetForm", pet);
            }

            if(pet.Id == 0)
            {
                pet.Active = true;
                pet.AddedIn = DateTime.Now;
                db.Pets.Add(pet);
            }
            else
            {
                var petInDb = db.Pets.Find(pet.Id);

                if (petInDb == null)
                    return HttpNotFound();

                Mapper.Map(pet, petInDb);
            }

            db.SaveChanges();

            return RedirectToAction("PetList");
        }


    }
}