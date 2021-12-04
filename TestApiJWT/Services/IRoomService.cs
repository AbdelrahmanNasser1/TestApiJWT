using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApiJWT.Models;

namespace TestApiJWT.Services
{
    public interface IRoomService
    {
        Task<string> AddApartment(RoomModel model);
        Task<IQueryable<string>> GetImages(String NameOfApartment);
    }
}
