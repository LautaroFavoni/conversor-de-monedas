namespace conversor_de_monedas.Data.Models
{
    public class RequestConversionDTO
    {
        public string monedaOrigenName { get; set; }
        public string monedaDestinoName { get; set; }
        public int cantidad { get; set; }

         
    }
}
