using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Database.Models;

namespace Core.Models
{
    public class UserForList
    {

        public UserForList()
        {
        }

        public UserForList(ApplicationUser user)
        {
            Id = user.Id;
            Name = user.Name;
        }
        

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
