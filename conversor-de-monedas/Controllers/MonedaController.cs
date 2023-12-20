using conversor_de_monedas.Data.Entities;
using conversor_de_monedas.Data.Models;
using conversor_de_monedas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace conversor_de_monedas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MonedaController : ControllerBase
    {
        private MonedaServices _monedaServices;

        public MonedaController(MonedaServices monedaServices)
        {
            _monedaServices = monedaServices;

        }


        [HttpGet("Get-Monedas-For-Admin")]
        public IActionResult GetMonedas()
        {
            return Ok(_monedaServices.GetMonedas());
        }

        [HttpPost("Mostrar-Moneda-por-ID")]
        public IActionResult GetMonedaID(int monedaID) 
        {
            return Ok(_monedaServices.GetMonedaById(monedaID));
        }

        [HttpPut("Conversion")]

        public IActionResult Conversion([FromBody] ResultadoConversionDTO request) 
        {
            int UsuarioID = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            ResultadoConversionDTO resultado = new ResultadoConversionDTO();

            resultado.monedaOrigenName = request.monedaOrigenName;
            resultado.monedaDestinoName = request.monedaDestinoName;
            resultado.cantidad = request.cantidad;
            resultado.resultado = (_monedaServices.Intercambio(UsuarioID, request.monedaOrigenName, request.monedaDestinoName, request.cantidad));

            return Ok(resultado);

            
        }

        [HttpGet("Get-Lista-Monedas")]
        public IActionResult GetListaDeMonedas ()
        {
            ListaMonedasDTO lista = new ListaMonedasDTO();
            lista.monedas = _monedaServices.GetListMonedas();

            return Ok(lista);

            
        }

        [HttpPost]
        public IActionResult CreateMoneda(CreateAndUpdateMonedaDTO createMonedaDto)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            _monedaServices.CreateMoneda(createMonedaDto);
            return Created("Created", createMonedaDto);
        }

        [HttpPut]

        public IActionResult UpdateMoneda(CreateAndUpdateMonedaDTO dto, int MonedaId)
        {
            _monedaServices.UpdateMoneda(dto, MonedaId);
            return NoContent();
        }


    }
}
