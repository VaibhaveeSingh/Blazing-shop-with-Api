using BlazingShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BlazingShop.Models.ViewModel;

namespace BlazingShop.Controllers
{
    public class AppointmentController : Controller
    {

        private ApplicationDbContext _context;

        public AppointmentController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Appointment
        public ActionResult Index()
        {
            var appointment = _context.Appointments.Include(a => a.Product).ToList();
            return View(appointment);
        }

        public ActionResult Details(int id)
        {
            var apt = _context.Appointments.SingleOrDefault(a => a.PId == id);
            return View(apt);

        }

        public ActionResult New()
        {
            var product = _context.Products.ToList();
            var vm = new NewAppointmentViewModel
            {
                Product = product
            };
            return View(vm);
        }
        [HttpPost]
        public ActionResult Save(Appointment appointment)
        {
            if (appointment.AId == 0)
                _context.Appointments.Add(appointment);
            else
            {
                var appInDb = _context.Appointments.Single(a => a.AId == appointment.AId);
                appInDb.PersonName = appointment.PersonName;
                appInDb.Email = appointment.Email;
                appInDb.PhoneNumber = appointment.PhoneNumber;
                appInDb.Date = appointment.Date;
                appInDb.IsConfirmed = appointment.IsConfirmed;
                appInDb.PId = appointment.PId;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Appointments");
        }
        public ActionResult Edit(int id)
        {
            var app = _context.Appointments.SingleOrDefault(a => a.AId == id);
            if (app == null)
            {
                return HttpNotFound();
            }
            var vm = new NewAppointmentViewModel
            {
                AId = app.AId,
                Date=app.Date,
                Email=app.Email,
                IsConfirmed=app.IsConfirmed,
                PersonName = app.PersonName,
                PhoneNumber = app.PhoneNumber,
            Product = _context.Products.ToList()
            };
            return View("New", vm);
        }

        public ActionResult Delete(int? id)
        {

            Appointment apt = _context.Appointments.Find(id);

            return View(apt);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete1(int id)
        {
            Appointment apt = _context.Appointments.Find(id);
            _context.Appointments.Remove(apt);
            _context.SaveChanges();
            return RedirectToAction("Index", "Appointment");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


    }
}