using Proyecto.Entities;
using Proyecto.Models;

namespace Proyecto.Data.Interfaces
{
    public interface IUserService
    {
        void Create(UserForCreationDto newuser);
        User GetById(int id);
        List<URL> GetAllUrls(int userId);
        User? ValidateUser(AuthenticationRequestBody authRequestBody);
        int Remainingshort(int userId);
        void ResetShortAmount(int userId);
        void DiscountShortAmount(int userId);

    }
}
