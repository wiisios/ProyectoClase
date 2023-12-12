using Proyecto.Data;
using Proyecto.Data.Interfaces;
using Proyecto.Entities;
using Proyecto.Models;


namespace Proyecto.Services
{
    public class UserService : IUserService
    {
        private readonly URLContext _context;


        public UserService(URLContext context)
        {
            _context = context;

        }

        public void Create(UserForCreationDto newuser)
        {
            User user = new User()
            {
                Username = newuser.Username,
                Email = newuser.Email,
                Password = newuser.Password,

            };
            _context.Users.Add(user);
            _context.SaveChanges();

        }

        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }

        public List<URL> GetAllUrls(int userId)
        {
            return _context.Urls.Where(u => u.UserId == userId).ToList();
        }
        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.Email == authRequestBody.Email && p.Password == authRequestBody.Password);
        }

        public int Remainingshort(int userId)
        {
            User user = GetById(userId);
            return user.ShortAmount;
        }

        public void ResetShortAmount(int userId)
        {
            User user = GetById(userId);

            user.ShortAmount = 10;

            
            _context.SaveChanges();
        }

        public void DiscountShortAmount(int userId)
        {
            User user = GetById(userId);

            user.ShortAmount -= 1;

            
            _context.SaveChanges();
        }




    }
}
