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

            return View("List", petViewModel);
        }

        public ActionResult PetForm(int? id)
        {
            Pet pet;
            PetFormViewModel petViewModel = new PetFormViewModel();
            var petBreedTypes = db.PetBreedTypes.ToList();
            var petSizes = db.PetSizes.ToList();
            var petTypes = db.PetTypes.ToList();
            var petGenders = db.PetGenders.ToList();

            if (id == null)
            {
                petViewModel = new PetFormViewModel
                {
                    Id = 0,
                    OwnerId = User.Identity.GetUserId(),
                    PetBreedTypes = petBreedTypes,
                    PetSizes = petSizes,
                    PetTypes = petTypes,
                    PetGenders = petGenders
                };
                return View("Form", petViewModel);
            }

            pet = db.Pets.Find(id);

            Mapper.Map(pet, petViewModel);
            petViewModel.PetTypes = petTypes;
            petViewModel.PetSizes = petSizes;
            petViewModel.PetBreedTypes = petBreedTypes;
            petViewModel.PetGenders = petGenders;

            return View("Form", petViewModel);
        }

        public ActionResult SalvarPet(PetFormViewModel petViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("PetForm", petViewModel);
            }

            var pet = new Pet();

            Mapper.Map(petViewModel, pet);

            if (petViewModel.LivesWithOwner)
            {
                var owner = db.Users.Find(petViewModel.OwnerId);
                pet.FillInAddress(owner);
            }
            else
            {
                var county = db.Counties.First(c => c.Name.Equals(petViewModel.CountyView));
                var state = db.States.First(s => s.Name.Equals(petViewModel.StateView));

                pet.StateId = state.Id;
                pet.CountyId = county.Id;
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