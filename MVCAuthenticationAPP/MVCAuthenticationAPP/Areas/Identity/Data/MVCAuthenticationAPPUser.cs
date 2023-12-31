﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVCAuthenticationAPP.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the MVCAuthenticationAPPUser class
    public class MVCAuthenticationAPPUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarChar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarChar(100)")]
        public string LastName { get; set; }
    }
}
