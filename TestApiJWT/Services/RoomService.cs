using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApiJWT.Models;

namespace TestApiJWT.Services
{
    public class RoomService : IRoomService
    {
        private readonly ApplicationDbCobtext _applicationDbCobtext;
        public RoomService(ApplicationDbCobtext applicationDbCobtext)
        {
            _applicationDbCobtext = applicationDbCobtext;
        }

        public async Task<string> AddApartment(RoomModel model)
        {
            var apartment = _applicationDbCobtext.ApartmentInfos.FirstOrDefault(i=>i.NameOfApartment == model.NameOfApartment);
            if (apartment != null)
            {
                return "Record is already added in Database";
            }
            var apartmentInfo = new ApartmentInfo
            {
                NameOfApartment = model.NameOfApartment,
                AddressOfApartment = model.AddressOfApartment,
                NumberOfRooms = model.NumberOfRooms,
                NumberOfBathRooms = model.NumberOfBathRooms,
                Size = model.Size,
                Images = model.Images
            };
             _applicationDbCobtext.ApartmentInfos.Add(apartmentInfo);
            _applicationDbCobtext.SaveChanges();
            return string.Empty;
        }
        public async Task<IQueryable<string>> GetImages(String NameOfApartment)
        {

            int apartment = _applicationDbCobtext.ApartmentInfos.Where(i => i.NameOfApartment == NameOfApartment).FirstOrDefault().Id;
            var listOfImages = _applicationDbCobtext.ImagesOfApartments.Where(i => i.ApartmentInfo.Id == apartment).Select(i => i.imageBytes);
            return listOfImages;
        }
    }
}
