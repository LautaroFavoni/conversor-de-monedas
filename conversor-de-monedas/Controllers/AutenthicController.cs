using AgendaApi.Models;
using conversor_de_monedas.Data.Models;
using conversor_de_monedas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace UrlShorter.Controllers
{

    [Route("api/autentic")]
    [ApiController]

    public class AutenthicController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserServices _userServices;

        public AutenthicController(IConfiguration config, UserServices userService)
        {
            _config = config; //Hacemos la inyección para poder usar el appsettings.json
            _userServices = userService;

        }

        [HttpPost("authenticate")] //Vamos a usar un POST ya que debemos enviar los datos para hacer el login
        public IActionResult Autenticar(AuthenticationRequestDto authenticationRequestBody) //Enviamos como parámetro la clase que creamos arriba
        {
            //Paso 1: Validamos las credenciales
            var user = _userServices.ValidateUser(authenticationRequestBody); //Lo primero que hacemos es llamar a una función que valide los parámetros que enviamos.

            if (user is null) //Si el la función de arriba no devuelve nada es porque los datos son incorrectos, por lo que devolvemos un Unauthorized (un status code 401).
                return Unauthorized();

            //Paso 2: Crear el token
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"])); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            //Los claims son datos en clave->valor que nos permite guardar data del usuario.
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
            claimsForToken.Add(new Claim("given_name", user.UserName)); //Lo mismo para given_name y family_name, son las convenciones para nombre y apellido. Ustedes pueden usar lo que quieran, pero si alguien que no conoce la app
            //claimsForToken.Add(new Claim("family_name", user.LastName)); quiere usar la API por lo general lo que espera es que se estén usando estas keys.
            claimsForToken.Add(new Claim("role", user.Role.ToString()));

            var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
              _config["Authentication:Issuer"],
              _config["Authentication:Audience"],
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credentials);

            var tokenToReturn = new JwtSecurityTokenHandler() //Pasamos el token a string
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);



            string userRole = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"))?.Value;
        }

        [HttpGet]
        public IActionResult EsAdmin()
        {
            string userRole = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"))?.Value;

            EsAdminDTO userAdmin = new EsAdminDTO();

            if (userRole == "ADMIN")
            {
                userAdmin.esadmin = true;
                return Ok(userAdmin);
            }
            userAdmin.esadmin = false;
            return Ok(userAdmin);

        }
    }
}
