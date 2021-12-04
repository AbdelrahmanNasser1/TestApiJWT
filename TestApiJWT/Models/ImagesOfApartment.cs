using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApiJWT.Models
{
    public class ImagesOfApartment
    {
        public int Id { get; set; }

        public string imageBytes { get; set; }
    
        public ApartmentInfo ApartmentInfo { get; set; }
    }
}
