using conversor_de_monedas.Data;
using conversor_de_monedas.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace conversor_de_monedas.Services
{
    public class UserServices
    {
        private readonly ConversorContext _context;
        public UserServices(ConversorContext context)
        {
            _context = context;
        }

        public List<User> GetUsuarios()
        {
            return _context.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.SingleOrDefault(c => c.Id == id);

        }

        public bool DeleteUser(int id)
        {
            User userToDelete = GetUser(id);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
                return true;

            }
            return false;

        }




    }

}
