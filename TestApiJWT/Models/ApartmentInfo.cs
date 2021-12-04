using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApiJWT.Models
{
    public class ApartmentInfo
    {
        public int Id { get; set; }
        public string NameOfApartment { get; set; }
        public string AddressOfApartment { get; set; }
        public int floor { get; set; }  
        public int NumberOfRooms { get; set; }
        public int NumberOfBathRooms { get; set; }
        public int Size { get; set; }
        public int IsPrepaired { get; set; }
        public List<ImagesOfApartment> Images { get; set; }
    }
}
