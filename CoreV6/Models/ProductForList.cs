using DataAccess.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ProductForList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string UserFullName { get; set; }

        public ProductForList(Product product )
        {
            Id=product.Id;
            Name=product.Name;
            Price=product.Price;
            //UserFullName=$"{product.User.Name}"
        }
    }
}
