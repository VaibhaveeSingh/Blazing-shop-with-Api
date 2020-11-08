using BlazingShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace BlazingShop.Controllers.Api
{
    public class AppointmentController : ApiController
    {
        private ApplicationDbContext db;
        public AppointmentController()
        {
            db = new ApplicationDbContext();
        }

        //Get /api/appointmentapi
        public IHttpActionResult GetAppointments()
        {
            var app = db.Appointments.Include(m => m.Product).ToList();

            if (app == null)
            {
                return NotFound();
            }
            return Ok(app);
        }

        public IHttpActionResult GetAppointments(int id)
        {
            var app = db.Appointments.Include(c => c.Product).SingleOrDefault(c => c.Id == id);
            if (app == null)
            {
                return NotFound();
            }

            return Ok(app);
        }

        //Post /api/appointmentapi
        [HttpPost]
        public IHttpActionResult CreateAppointment(Appointment app)
        {

            db.Appointments.Add(app);
            db.SaveChanges();
            return Ok(app);
        }

        //Put /api/customerapi/1
        [HttpPut]
        public IHttpActionResult UpdateAppointment(int id, Appointment app)
        {

            var appInDb = db.Appointments.Include(c => c.Product).SingleOrDefault(c => c.Id == id);
            if (appInDb == null)
            {

                return NotFound();
            }

            appInDb.Name = app.Name;
            appInDb.Email = app.Email;
            appInDb.Phone = app.Phone;
            appInDb.Date = app.Date;
            appInDb.ProductId = app.ProductId;

            db.SaveChanges();
            return Ok();
        }

        //Delete /api/appointmentapi/1

        public IHttpActionResult DeleteAppointment(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a Valid Appointment id");
            }
            var appInDb = db.Appointments.SingleOrDefault(c => c.Id == id);
            if (appInDb == null)
            {

                return NotFound();
            }

            db.Appointments.Remove(appInDb);
            db.SaveChanges();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}

