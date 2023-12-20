using conversor_de_monedas.Data;
using conversor_de_monedas.Data.Entities;
using conversor_de_monedas.Data.Models;
using conversor_de_monedas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace conversor_de_monedas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private UserServices _userServices;

        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            Console.WriteLine("todoOK");
            return Ok(_userServices.GetUsuarios());

        }

        [HttpPost]
        public IActionResult GetUsuariobyID(int id)
        {
             
            return Ok(_userServices.GetUser(id));

        }
        [HttpGet("Get-Nombre-Categoria")]
        public IActionResult GetNombreCateogoria()
        {
            Suscripcion respuesta = new Suscripcion();
            int UsuarioID = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            respuesta = _userServices.GetCategoria(UsuarioID);

            return Ok(respuesta);

        }
        [HttpGet("Get-Usuario-Logged")]
        public IActionResult GetUsuarioLogged()
        {
            UsuarioLoggedDTO respuesta = new UsuarioLoggedDTO();
            int UsuarioID = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            respuesta = _userServices.GetUsuarioLogged(UsuarioID);

            return Ok(respuesta);

        }
        [HttpPut("Cambiar-Categoria")]
        public IActionResult ModificarCategoria([FromQuery]int IdCategoria) 
        {
            int UsuarioID = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            User usuario = _userServices.CambiarCategoria(UsuarioID, IdCategoria);

            
            return Ok(usuario);
        
        }
        [HttpGet("Get-User-For-Admin")]
        public IActionResult GetUserForAdmin()
        {

            return Ok(_userServices.GetUsuarios()) ;
        }

        [AllowAnonymous]
        [HttpPost ("Crear-Usuario")]
        public IActionResult CreateUser(CreateAndUpdateUserDto dto)
        {
            try
            {
                _userServices.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", dto);
        }



    }
}
