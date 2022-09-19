﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
    }
}
