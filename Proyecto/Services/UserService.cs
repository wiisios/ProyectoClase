using Proyecto.Data;
using Proyecto.Entities;
using Proyecto.Models;

namespace Proyecto.Services
{
    public class UserService
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
        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.Email == authRequestBody.Email && p.Password == authRequestBody.Password);
        }

        
    }
}
