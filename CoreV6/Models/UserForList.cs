using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataBase.Models;

namespace Core.Models
{
    public class UserForList
    {

        public UserForList()
        {
        }

        public UserForList(User user)
        {
            Id = user.Id;
            Name = user.Name;
        }
        

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
