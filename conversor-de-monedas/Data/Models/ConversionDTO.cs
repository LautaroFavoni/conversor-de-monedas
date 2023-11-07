using conversor_de_monedas.Data.Entities;

namespace conversor_de_monedas.Data.Models
{
    public class ConversionDTO
    {
        
            public User Usuario { get; set; }
            public Moneda MonedaOrigen { get; set; }
            public Moneda MonedaDestino { get; set; }
            public int Cantidad { get; set; }
        

    }
}
