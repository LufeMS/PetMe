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
            var state = db.States.Find(user.StateId);
            var county = db.Counties.Find(user.CountyId);

            if (user == null)
            {
                return HttpNotFound();
            }

            var userViewModel = Mapper.Map<ApplicationUser, UserProfileViewModel>(user);
            userViewModel.State = state.Name;
            userViewModel.County = county.Name;

            return View("Info", userViewModel);
        }

        public ActionResult SaveUser(UserProfileViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return View("Info", userViewModel);

            var user = db.Users.Find(userViewModel.Id);

            if (user == null)
                return HttpNotFound();

            var state = db.States.Single(s => s.Name.Equals(userViewModel.State));
            var county = db.Counties.Single(s => s.Name.Equals(userViewModel.County));

            Mapper.Map(userViewModel, user);
            user.StateId = state.Id;
            user.CountyId = county.Id;
            user.FormOk = true;
            user.Deleted = false;

            db.SaveChanges();

            return View("Info", userViewModel);
        }
    }
}