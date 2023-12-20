namespace conversor_de_monedas.Data.Models
{
    public class UserForAdminDTO
    {
        public string userName { get; set; }
        public string email { get; set; }

        public string role { get; set; }

        public int categoriaId { get; set; }
    }
}
