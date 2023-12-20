using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace conversor_de_monedas.Data.Entities
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
        public int Tiros { get; set; }

        [ForeignKey("SuscripcionId")]
        public Suscripcion Suscripcion { get; set; }
        public int SuscripcionId { get; set; }



    }

}

