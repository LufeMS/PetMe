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
                ReceiverId = petVM.OwnerInfo.Id,
                AdoptionId = 0
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
                AdoptionStart = DateTime.Now                
            };

            db.Adoptions.Add(adoption);
            db.SaveChanges();
            
            var adoptionMail = new AdoptionMail
            {
                AdoptionId = adoption.Id,
                ReceiverId = adoptionMailVM.ReceiverId,
                SenderId = adoptionMailVM.SenderId,
                SentDate = DateTime.Now,
                Text = adoptionMailVM.Text
            };

            db.AdoptionMails.Add(adoptionMail);
            db.SaveChanges();

            return RedirectToAction("PetOwnerList", "Pets");
        }

        public ActionResult MyAdoptions()
        {
            var userId = User.Identity.GetUserId();
            var adoptions = new List<AdoptionViewModel>();
            var adoptionsInDb = db.Adoptions.Where(a => a.InterestedUserId == userId || a.PetOwnerId == userId).ToList();

            foreach (var adoption in adoptionsInDb)
            {
                adoptions.Add(new AdoptionViewModel
                {
                    Adoption = adoption,
                    InterestedPartyInfo = db.Users.Find(adoption.InterestedUserId),
                    OwnerInfo = db.Users.Find(adoption.PetOwnerId),
                    PetInfo = db.Pets.Find(adoption.AnimalId),
                    CurrentUserId = User.Identity.GetUserId()
                });
            }

            return View("AdoptionList", adoptions);
        }

        public ActionResult AdoptionInfo(int id)
        {
            var adoption = db.Adoptions.Find(id);

            if (adoption == null)
                return HttpNotFound();

            var currentUserId = User.Identity.GetUserId();
            var owner = db.Users.Find(adoption.PetOwnerId);
            var interestedUserId = db.Users.Find(adoption.InterestedUserId);
            var pet = db.Pets.Find(adoption.AnimalId);

            var adoptionVM = new AdoptionViewModel
            {
                Adoption = adoption,
                CurrentUserId = currentUserId,
                OwnerInfo = owner,
                InterestedPartyInfo = interestedUserId,
                PetInfo = pet
            };

            return View("AdoptionInfo", adoptionVM);
        }

        public ActionResult RenderMails(int id)
        {
            var mails = db.AdoptionMails.Where(am => am.AdoptionId == id).ToList();

            var mailsVM = new List<AdoptionMailViewModel>();

            foreach (var mail in mails)
            {
                mailsVM.Add(new AdoptionMailViewModel
                {
                    AdoptionId = mail.AdoptionId,
                    Id = mail.Id,
                    ReceiverId = mail.ReceiverId,
                    SenderId = mail.SenderId,
                    SentDate = mail.SentDate,
                    Text = mail.Text
                });
            }

            return PartialView("_Mails", mailsVM);
        }

        public ActionResult AcceptAdoption(int id)
        {

        }
    }
}