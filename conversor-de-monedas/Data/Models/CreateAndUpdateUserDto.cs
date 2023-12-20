using conversor_de_monedas.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace conversor_de_monedas.Data.Models
{
    public class CreateAndUpdateUserDto
    {
        
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; } = "Free";
        public int Tiros { get; set; } = 0;

        [ForeignKey("SuscripcionId")]
        
        public int SuscripcionId { get; set; } = 1;

    }
}
