﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApiJWT.Models
{
    public class ApplicatonClass : IdentityUser
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required , MaxLength(50)]
        public string LastName { get; set; }
    }
}
