using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApiJWT.Models
{
    public class RegisterModel
    {
        [Required, StringLength(100)]
        public string Firstname { get; set; }
        [Required, StringLength(100)]
        public string Lastname { get; set; }
        [Required, StringLength(50)]
        public string Username { get; set; }
        [Required, StringLength(100)]
        public string Email { get; set; }
        [Required, StringLength(50)]
        public string Password { get; set; }
       
    }
}
