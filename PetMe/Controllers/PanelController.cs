using PetMe.Models;
using PetMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;

namespace PetMe.Controllers
{
    public class PanelController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Panel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserForm(string id)
        {
            var user = db.Users.Find(id);

            if(user == null)
            {
                return HttpNotFound();
            }

            var userViewModel = Mapper.Map<ApplicationUser, UserViewModel>(user);
            
            return View("Info", userViewModel);
        }

        public ActionResult PetList(string id)
        {
            var user = db.Users.Find(id);

            if(user == null)
            {
                return View("Login");
            }

            var pets = db.Pets.Where(p => p.DonoId == id).ToList();

            var petViewModel = new PetViewModel
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
                    DonoId = User.Identity.GetUserId()
                };
                return View(pet);
            }

            pet = db.Pets.Find(id);

            return View(pet);
        }
    }
}