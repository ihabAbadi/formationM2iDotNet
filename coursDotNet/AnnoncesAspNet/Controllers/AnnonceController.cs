using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnoncesAspNet.Interface;
using AnnoncesAspNet.Models;
using AnnoncesAspNet.Tools;
using AnnoncesAspNet.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnnoncesAspNet.Controllers
{
    public class AnnonceController : Controller
    {
        IUpload _upload;
        public AnnonceController(IUpload upload)
        {
            _upload = upload;
        }
        [HttpGet]
        public IActionResult Index()
        {
            AnnoncesViewModel vm = new AnnoncesViewModel();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            AnnoncesViewModel vm = new AnnoncesViewModel();
            vm.Annonces = Annonce.GetAnnonces(search);
            return View("Index", vm);
        }

        [HttpGet]
        public IActionResult SearchCategorie(int id)
        {
            AnnoncesViewModel vm = new AnnoncesViewModel();
            vm.Annonces = Annonce.GetAnnoncesByCategorie(id);
            return View("Index", vm);
        }

        [HttpGet]
        public IActionResult FormAnnonce(int? id)
        {
            Annonce annonce = new Annonce();
            if(id != null)
            {
                annonce = Annonce.GetAnnonce((int)id);
            }
            ViewBag.Categories = DataContext.Instance.Categories.ToList();
            return View(annonce);
        }

        [HttpPost]
        public IActionResult SubmitAnnonce([FromForm] Annonce annonce, List<IFormFile> images, List<int> categories)
        {
            if(annonce.Id == 0)
            {
                SetCategories(annonce, categories);
                SetImages(annonce, images);
                DataContext.Instance.Annonces.Add(annonce);
                DataContext.Instance.SaveChanges();
            }
            else
            {
                Annonce annonceSaved = Annonce.GetAnnonce(annonce.Id);
                if(annonceSaved != null)
                {
                    annonceSaved.Categories.Clear();
                    annonceSaved.Images.Clear();
                    SetCategories(annonceSaved, categories);
                    SetImages(annonceSaved, images);
                    annonceSaved.Title = annonce.Title;
                    annonceSaved.Description = annonce.Description;
                    DataContext.Instance.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        } 

        [HttpGet]
        public IActionResult DeleteAnnonce(int id)
        {
            Annonce annonce = DataContext.Instance.Annonces.FirstOrDefault((a) => a.Id == id);
            if(annonce != null)
            {
                DataContext.Instance.Annonces.Remove(annonce);
                DataContext.Instance.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        private void SetCategories(Annonce annonce, List<int> categories)
        {
            categories.ForEach(i =>
            {
                annonce.Categories.Add(new AnnonceCategorie()
                {
                    Annonce = annonce,
                    Categorie = DataContext.Instance.Categories.Find(i)
                });
            });
        }

        private void SetImages(Annonce annonce, List<IFormFile> images)
        {
            images.ForEach(img =>
            {
                Image image = new Image()
                {
                    Url = _upload.Upload(img)
                };
                annonce.Images.Add(image);
            });
        }
    }
}
