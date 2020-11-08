using BlazingShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BlazingShop.Models.ViewModel;
using System.IO;
using Microsoft.AspNetCore.Http;


namespace BlazingShop.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;


        public ProductController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Product
        public ActionResult Index()
        {
            var product = _context.Products.Include(c => c.Category).ToList();

            return View(product);
        }

        public ActionResult Details(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            return View(product);
        }


        public ActionResult Create()
        {
            var category1 = _context.Categories.ToList();
            var viewModel = new NewCategoryViewModel
            {
                Category = category1
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product product)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
            product.Image = ConvertToBytes(file);
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCategoryViewModel(product)
                {
                    Category = _context.Categories.ToList()
                };
                return View("Create", viewModel);
            }

            if (product.Id == 0)
                _context.Products.Add(product);
            else
            {
                //var prodInDb = _context.Products.Single(c => c.Id == product.Id);
                //prodInDb.Name = product.Name;
                //prodInDb.Price = product.Price;
                //prodInDb.ShadeColour = product.ShadeColour;
                //prodInDb.Image = product.Image;
                //prodInDb.CId = product.CId;



            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Product");


        }

        [HttpGet]

        public ActionResult Edit(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var vm = new NewCategoryViewModel(product)
            {

                //Name = product.Name,
                //Id= product.Id,
                //Price= product.Price,
                //ShadeColour= product.ShadeColour,
                //Image = product.Image,
                //CId=product.CId,
              
                Category = _context.Categories.ToList()
            };

            return View("Create", vm);
        }

        public ActionResult Delete(int id)
        {

            Product product = _context.Products.Find(id);
            if (product== null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Product product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }




        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }


        public ActionResult RetrieveImage(int id)
        {
            byte[] cover;
            var q = from p in _context.Products where p.Id == id select p.Image;
            cover = q.First();
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }





        public ActionResult Delete(int? id)
        {

            Product product = _context.Products.Find(id);

            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete1(int id)
        {
            Product product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }



        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


    }

}


