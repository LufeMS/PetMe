using PetMe.Models;
using PetMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetMe.Controllers
{
    public class AdoptionsController : Controller
    {
        ApplicationDbContext db;

        public AdoptionsController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Adoptions
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Adopt(PetInfoViewModel petVM)
        {
            if (petVM.UserInfo == null || petVM.OwnerInfo == null || petVM.PetInfo == null)
                return HttpNotFound();

            var adoptionMail = new AdoptionMailViewModel
            {
                AnimalId = petVM.PetInfo.Id,
                SenderId = petVM.UserInfo.Id,
                ReceiverId = petVM.OwnerInfo.Id
            };

            return View("AdoptionConfirmation", adoptionMail);
        }

        public ActionResult ConfirmAdoptionRequest(AdoptionMailViewModel adoptionMailVM)
        {
            if (!ModelState.IsValid)
            {
                return View("AdoptionConfirmation", adoptionMailVM);
            }

            var adoption = new Adoption
            {
                InterestedUserId = adoptionMailVM.SenderId,
                PetOwnerId = adoptionMailVM.ReceiverId,
                AnimalId = adoptionMailVM.AnimalId,
                AdoptionStatusId = 1,
                AdoptionStart = new DateTime()                
            };

            db.Adoptions.Add(adoption);

            var adoptionMail = new AdoptionMail
            {
                AdoptionId = adoption.Id,
                ReceiverId = adoptionMailVM.ReceiverId,
                SenderId = adoptionMailVM.SenderId,
                SentDate = new DateTime(),
                Text = adoptionMailVM.Text
            };

            db.AdoptionMails.Add(adoptionMail);

            return View("List");
        }
    }
}