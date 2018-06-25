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

        public ActionResult Filter(PetListViewModel petViewModel)
        {
            if (!ModelState.IsValid)
                return View("List", petViewModel);

            IEnumerable<Pet> petsFiltered;

            if (petViewModel.User != null)
                petsFiltered = db.Pets.Where(p => p.OwnerId.Equals(petViewModel.User.Id)).ToList();
            else
                petsFiltered = db.Pets.ToList();

            if (petViewModel.Filter.PetBreedTypeId != null)
                petsFiltered = petsFiltered.Where(p => p.PetBreedTypeId == petViewModel.Filter.PetBreedTypeId);

            if (petViewModel.Filter.PetGenderId != null)
                petsFiltered = petsFiltered.Where(p => p.PetGenderId == petViewModel.Filter.PetGenderId);

            if (petViewModel.Filter.PetSizeId != null)
                petsFiltered = petsFiltered.Where(p => p.PetSizeId == petViewModel.Filter.PetSizeId);

            if (petViewModel.Filter.PetTypeId != null)
                petsFiltered = petsFiltered.Where(p => p.PetTypeId == petViewModel.Filter.PetTypeId);

            if (petViewModel.Filter.StateId != null)
                petsFiltered = petsFiltered.Where(p => p.StateId == petViewModel.Filter.StateId);

            if (petViewModel.Filter.CountyId != null)
                petsFiltered = petsFiltered.Where(p => p.StateId == petViewModel.Filter.CountyId);

            if (petViewModel.Filter.AgeRange != null)
            {
                if(petViewModel.Filter.AgeRange == PetFilter.PetAgeRanges.lessThanOne)
                    petsFiltered = petsFiltered.Where(p => p.AgeInMonths < 12);

                else if (petViewModel.Filter.AgeRange == PetFilter.PetAgeRanges.betweenOneAndFive)
                    petsFiltered = petsFiltered.Where(p => p.AgeInMonths >= 12 && p.AgeInMonths <= 71);

                else if (petViewModel.Filter.AgeRange == PetFilter.PetAgeRanges.greaterThanSix)
                    petsFiltered = petsFiltered.Where(p => p.AgeInMonths >= 72);
            }

            petsFiltered = petsFiltered.Where(p => p.Castrated == petViewModel.Filter.Castrated
                                    && p.Trained == petViewModel.Filter.Trained
                                    && p.Vaccinated == petViewModel.Filter.Vaccinated
                                    && p.SpecialCare == petViewModel.Filter.SpecialCare);

            var petBreedTypes = db.PetBreedTypes.ToList();
            var petSizes = db.PetSizes.ToList();
            var petTypes = db.PetTypes.ToList();
            var petGenders = db.PetGenders.ToList();
            var counties = db.Counties.ToList();
            var states = db.States.ToList();

            petViewModel.Pets = petsFiltered;
            petViewModel.Filter.PetBreedTypes = petBreedTypes;
            petViewModel.Filter.PetSizes = petSizes;
            petViewModel.Filter.PetTypes = petTypes;
            petViewModel.Filter.PetGenders = petGenders;
            petViewModel.Filter.Counties = counties;
            petViewModel.Filter.States = states;

            if (petViewModel.User != null)
                return View("OwnerList", petViewModel);

            return View("List", petViewModel);
        }

        public ActionResult PetOwnerList()
        {
            string id = User.Identity.GetUserId();

            var user = db.Users.Find(id);

            if (user == null)
            {
                return View("Login");
            }

            var petBreedTypes = db.PetBreedTypes.ToList();
            var petSizes = db.PetSizes.ToList();
            var petTypes = db.PetTypes.ToList();
            var petGenders = db.PetGenders.ToList();
            var counties = db.Counties.ToList();
            var states = db.States.ToList();

            var pets = db.Pets.Where(p => p.OwnerId == id).ToList();

            var petViewModel = new PetListViewModel
            {
                Filter = new PetFilter
                {
                    PetBreedTypes = petBreedTypes,
                    PetGenders = petGenders,
                    PetSizes = petSizes,
                    PetTypes = petTypes,
                    States = states,
                    Counties = counties,
                },

                User = user,
                Pets = pets
            };

            return View("OwnerList", petViewModel);
        }

        public ActionResult PetList()
        {
            var pets = db.Pets.ToList();

            var petBreedTypes = db.PetBreedTypes.ToList();
            var petSizes = db.PetSizes.ToList();
            var petTypes = db.PetTypes.ToList();
            var petGenders = db.PetGenders.ToList();
            var counties = db.Counties.ToList();
            var states = db.States.ToList();

            var petViewModel = new PetListViewModel
            {
                Filter = new PetFilter
                {
                    PetBreedTypes = petBreedTypes,
                    PetGenders = petGenders,
                    PetSizes = petSizes,
                    PetTypes = petTypes,
                    States = states,
                    Counties = counties,
                },

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

            if (pet == null)
                return HttpNotFound();

            var county = db.Counties.Find(pet.CountyId);
            var state = db.States.Find(pet.StateId);
            var petPictures = db.PetPictures.Where(pp => pp.PetId == pet.Id).ToList();

            Mapper.Map(pet, petViewModel);
            petViewModel.PetTypes = petTypes;
            petViewModel.PetSizes = petSizes;
            petViewModel.PetBreedTypes = petBreedTypes;
            petViewModel.PetGenders = petGenders;
            petViewModel.CountyView = county.Name;
            petViewModel.StateView = state.Abbreviation;
            petViewModel.PetPictures = petPictures;

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

            return RedirectToAction("PetOwnerList");
        }

        public ActionResult PetInfo(int id)
        {
            var pet = db.Pets.Find(id);

            if (pet == null)
            {
                return HttpNotFound();
            }

            var owner = db.Users.Find(pet.OwnerId);
            var user = db.Users.Find(User.Identity.GetUserId());

            var petViewModel = new PetInfoViewModel
            {
                PetInfo = pet,
                UserInfo = user,
                OwnerInfo = owner
            };

            return View("Info", petViewModel);
        }

        public ActionResult DeletePet(int id)
        {
            var pet = db.Pets.Find(id);

            if (pet == null)
                return HttpNotFound();

            db.Pets.Remove(pet);
            db.SaveChanges();

            return RedirectToAction("PetOwnerList");
        }
    }
}