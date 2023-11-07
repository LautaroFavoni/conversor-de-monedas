using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace conversor_de_monedas.Data.Entities
{
    public class Conversion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("IdMonedaOrigen")]

        public Moneda MonedaOrigen { get; set; }
        public int IdMonedaOrigen { get; set; }

        [ForeignKey("IdMonedaDestino")]

        public Moneda MonedaDestino { get; set; }
        public int IdMonedaDestino { get; set; }
        public DateTime fecha { get; set; }

        [ForeignKey("IdUser")]
        public User UserConversor { get; set; }
        public int IdUser { get; set; }

    }
}
