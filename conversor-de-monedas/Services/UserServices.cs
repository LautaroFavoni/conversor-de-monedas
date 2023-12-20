using AgendaApi.Models;
using conversor_de_monedas.Data;
using conversor_de_monedas.Data.Entities;
using conversor_de_monedas.Data.Models;
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

        public List<UserForAdminDTO> GetUsuarios()
        {
            var usuarios = _context.Users.Select(u => new UserForAdminDTO
            {
                userName = u.UserName,
                email = u.Email,
                role = u.Role,
                categoriaId = u.SuscripcionId
            }).ToList();

            return usuarios;
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

        public User? GetByUserName(string Name)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == Name);
        }

        public bool ValidateCredentials(string Name, string password)
        {
            User? UserForLoggin = GetByUserName(Name);
            if (UserForLoggin != null)
            {
                if (UserForLoggin.Password != password)
                    return true;
            }
            return false;

        }

        public User? ValidateUser(AuthenticationRequestDto authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.UserName == authRequestBody.Name && p.Password == authRequestBody.Password);
        }

        public Suscripcion GetCategoria(int id)
        {
            User user = GetUser(id);
            if (user != null)
            {
                Suscripcion categoria = _context.suscripciones.SingleOrDefault(s => s.Id == user.SuscripcionId);
                return categoria;

            }


            return null;
        }

        public UsuarioLoggedDTO GetUsuarioLogged(int id)
        {
            UsuarioLoggedDTO UsuarioLogged = new UsuarioLoggedDTO();
            User user = GetUser(id);
            if (user != null)
            {
                UsuarioLogged.Tiros = user.Tiros;
                UsuarioLogged.Role = user.Role;
                UsuarioLogged.UserName = user.UserName;

                return UsuarioLogged;

            }
            return UsuarioLogged;




        }

        public User  CambiarCategoria(int idUsuario, int idCategoria)
        {
            User usuario = GetUser(idUsuario);
            // Verificar si la categoría existe
            if (_context.suscripciones.Any(c => c.Id == idCategoria))
            {
                
                usuario.SuscripcionId = idCategoria;
                _context.SaveChanges();
                return usuario;
            }
            else
            {
                // La categoría no existe, puedes manejar este caso según tus necesidades
                return usuario;
            }
        }

        public void Create(CreateAndUpdateUserDto dto)
        {
            User newUser = new User()
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Password = dto.Password,
                Tiros = dto.Tiros,
                SuscripcionId = dto.SuscripcionId,
                Role = dto.Role,
                
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

    }

}

