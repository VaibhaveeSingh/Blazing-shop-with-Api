using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlazingShop.Models.ViewModel
{
    public class NewAppointmentViewModel
    {
        public IEnumerable<Product> Product { get; set; }

        public int ?AId { get; set; }
        public string PersonName { get; set; }


        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime Date { get; set; }

        public long PhoneNumber { get; set; }
        public bool IsConfirmed { get; set; }
        //public Product Product { get; set; }
        public int ?PId { get; set; }

    }
}