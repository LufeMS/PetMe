﻿using Microsoft.AspNet.Identity;
using PetMe.Models;
using PetMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetMe.Controllers
{
    [Authorize]
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

        public ActionResult ConfirmAdoptionRequest(string text, string ReceiverId, string SenderId, int AnimalId)
        {
            var adoption = new Adoption
            {
                InterestedUserId = SenderId,
                PetOwnerId = ReceiverId,
                AnimalId = AnimalId,
                AdoptionStatusId = 1,
                AdoptionStart = DateTime.Now                
            };

            db.Adoptions.Add(adoption);
            db.SaveChanges();
            
            var adoptionMail = new AdoptionMail
            {
                AdoptionId = adoption.Id,
                ReceiverId = ReceiverId,
                SenderId = SenderId,
                SentDate = DateTime.Now,
                Text = text
            };

            db.AdoptionMails.Add(adoptionMail);
            db.SaveChanges();

            return RedirectToAction("PetList", "Pets");
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
            var adoption = db.Adoptions.Find(id);

            if (adoption == null)
                return HttpNotFound();

            var owner = db.Users.Find(adoption.PetOwnerId);
            var interestedParty = db.Users.Find(adoption.InterestedUserId);
            var pet = db.Pets.Find(adoption.AnimalId);

            adoption.AdoptionStatusId = AdoptionStatus.inProgress;

            db.SaveChanges();

            var adoptionVM = new AdoptionViewModel
            {
                Adoption = adoption,
                CurrentUserId = User.Identity.GetUserId(),
                OwnerInfo = owner,
                InterestedPartyInfo = interestedParty,
                PetInfo = pet
            };

            return View("AdoptionInfo", adoptionVM);
        }

        public ActionResult StartTransfer(int id)
        {
            var adoption = db.Adoptions.Find(id);

            if (adoption == null)
                return HttpNotFound();

            var owner = db.Users.Find(adoption.PetOwnerId);
            var interestedParty = db.Users.Find(adoption.InterestedUserId);
            var pet = db.Pets.Find(adoption.AnimalId);
            var currentUserId = User.Identity.GetUserId();

            if (adoption.InterestedUserId == currentUserId)
                adoption.InterestedUserPermission = true;

            else if (adoption.PetOwnerId == currentUserId)
                adoption.PetOwnerPermission = true;

            if (adoption.InterestedUserPermission && adoption.PetOwnerPermission)
            {
                adoption.AdoptionStatusId = AdoptionStatus.awaitingTransfer;
                adoption.InterestedUserPermission = false;
                adoption.PetOwnerPermission = false;
            }

            db.SaveChanges();

            var adoptionVM = new AdoptionViewModel
            {
                Adoption = adoption,
                CurrentUserId = currentUserId,
                OwnerInfo = owner,
                InterestedPartyInfo = interestedParty,
                PetInfo = pet
            };

            return View("AdoptionInfo", adoptionVM);
        }

        public ActionResult FinishAdoption(int id)
        {
            var adoption = db.Adoptions.Find(id);
         
            if (adoption == null)
                return HttpNotFound();

            var owner = db.Users.Find(adoption.PetOwnerId);
            var interestedParty = db.Users.Find(adoption.InterestedUserId);
            var pet = db.Pets.Find(adoption.AnimalId);
            var currentUserId = User.Identity.GetUserId();

            if (adoption.InterestedUserId == currentUserId)
                adoption.InterestedUserPermission = true;
            
            else if(adoption.PetOwnerId == currentUserId)
                adoption.PetOwnerPermission = true;

            if (adoption.InterestedUserPermission && adoption.PetOwnerPermission)
            {
                adoption.AdoptionStatusId = AdoptionStatus.finished;
                adoption.AdoptionEnd = DateTime.Now;
            }

            db.SaveChanges();

            var adoptionVM = new AdoptionViewModel
            {
                Adoption = adoption,
                CurrentUserId = currentUserId,
                OwnerInfo = owner,
                InterestedPartyInfo = interestedParty,
                PetInfo = pet
            };

            return View("AdoptionInfo", adoptionVM);
        }

        public ActionResult CancelAdoption(int id)
        {
            var adoption = db.Adoptions.Find(id);

            if (adoption == null)
                return HttpNotFound();

            var owner = db.Users.Find(adoption.PetOwnerId);
            var interestedParty = db.Users.Find(adoption.InterestedUserId);
            var pet = db.Pets.Find(adoption.AnimalId);
            var currentUserId = User.Identity.GetUserId();

            adoption.AdoptionStatusId = AdoptionStatus.cancelled;
            adoption.AdoptionEnd = DateTime.Now;

            db.SaveChanges();

            var adoptionVM = new AdoptionViewModel
            {
                Adoption = adoption,
                CurrentUserId = currentUserId,
                OwnerInfo = owner,
                InterestedPartyInfo = interestedParty,
                PetInfo = pet
            };
            
            return View("AdoptionInfo", adoptionVM);
        }

        public ActionResult SendMessage(string text, string petOwnerId, string interestedPartyId, string currentUserId, int adoptionId)
        {
            string receiverId, senderId;

            if (interestedPartyId == currentUserId)
            {
                receiverId = petOwnerId;
                senderId = interestedPartyId;
            }
            else
            {
                receiverId = interestedPartyId;
                senderId = petOwnerId;
            }

            if (!String.IsNullOrEmpty(text))
            {
                var message = new AdoptionMail
                {
                    AdoptionId = adoptionId,
                    ReceiverId = receiverId,
                    SenderId = senderId,
                    SentDate = DateTime.Now,
                    Text = text
                };

                db.AdoptionMails.Add(message);
                db.SaveChanges();
            }

            return RedirectToAction("RenderMails", new { id = adoptionId});
        }
    }
}