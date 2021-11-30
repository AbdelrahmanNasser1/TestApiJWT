using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApiJWT.Models
{
    public class ApplicationDbCobtext : IdentityDbContext<ApplicatonClass>
    {
        public ApplicationDbCobtext(DbContextOptions<ApplicationDbCobtext>options) :base(options)
        {

        }
    }

}
