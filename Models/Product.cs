using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlazingShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public double Price { get; set; }

        public string ShadeColour { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }
        public Category Category { get; set; }

        public int CId { get; set; }
    }
}