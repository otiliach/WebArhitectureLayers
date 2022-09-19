using System;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess.Database.Models
{
    public class Product
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
