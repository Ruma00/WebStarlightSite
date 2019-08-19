using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StarlightProject_Site.Models
{
    public class StarlightUser : IdentityUser
    {
        public StarlightUser() : base()
        { }

        public List<int> Stories { get; set; }
    }
}
