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

            var userViewModel = Mapper.Map<ApplicationUser, UserFormViewModel>(user);
            
            return View("Info", userViewModel);
        }
        
    }
}