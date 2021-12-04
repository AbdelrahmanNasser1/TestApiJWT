using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApiJWT.Models
{
    public class RoomModel
    {

        [Required , MaxLength(250)]
        public string NameOfApartment { get; set; }
        [Required , MaxLength(3000)]
        public string AddressOfApartment { get; set; }
        [Required]
        public int floor { get; set; }
        [Required]
        public int NumberOfRooms { get; set; }
        [Required]
        public int NumberOfBathRooms { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public int IsPrepaired { get; set; }
        [Required]
        public List<ImagesOfApartment> Images { get; set; }

    }
}
