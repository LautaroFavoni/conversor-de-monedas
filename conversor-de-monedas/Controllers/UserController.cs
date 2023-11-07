using conversor_de_monedas.Data;
using conversor_de_monedas.Data.Entities;
using conversor_de_monedas.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace conversor_de_monedas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

    }
}
