using conversor_de_monedas.Data.Entities;
using conversor_de_monedas.Data.Models;
using conversor_de_monedas.Services;
using Microsoft.AspNetCore.Mvc;

namespace conversor_de_monedas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : ControllerBase
    {
        private MonedaServices _monedaServices;

        public MonedaController(MonedaServices monedaServices)
        {
            _monedaServices = monedaServices;

        }


        [HttpGet]
        public IActionResult GetMonedas()
        {
            return Ok(_monedaServices.GetMonedas());
        }

        [HttpPost("Mostrar-Moneda-por-ID")]
        public IActionResult GetMonedaID(int monedaID) 
        {
            return Ok(_monedaServices.GetMoneda(monedaID));
        }

        [HttpPut("Conversion")]
        public IActionResult Conversion([FromBody] ConversionDTO ConvertDTO)
        {
            return Ok(_monedaServices.Intercambio(ConvertDTO.Usuario , ConvertDTO.MonedaOrigen, ConvertDTO.MonedaDestino, ConvertDTO.Cantidad));
        }
    }
}
