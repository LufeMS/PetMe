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
    public class ProfileController : Controller
    {
        private ApplicationDbContext db;

        public ProfileController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Profile
        public ActionResult MyProfile()
        {
            var id = User.Identity.GetUserId();
            var user = db.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            var userViewModel = Mapper.Map<ApplicationUser, UserProfileViewModel>(user);

            return View("Info", userViewModel);
        }
    }
}