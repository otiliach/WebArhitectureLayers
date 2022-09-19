using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public ApplicationUser User { get; set; }
    }
}
