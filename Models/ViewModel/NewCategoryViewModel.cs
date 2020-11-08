using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlazingShop.Models.ViewModel
{
    public class NewCategoryViewModel
    {
        public IEnumerable<Category> Category { get; set; }
        //public Product Product { get; set; }
        public int ?Id { get; set; }
        public double Price { get; set; }

        public string ShadeColour { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }
        //public Category Category { get; set; }

        public int ?CId { get; set; }

        public NewCategoryViewModel()
        {
            Id = 0;
        }

        public NewCategoryViewModel(Product product)
        {
            Name = product.Name;
            Id = product.Id;
            Price = product.Price;
            ShadeColour = product.ShadeColour;
            Image = product.Image;
            CId = product.CId;
        }
    }
}