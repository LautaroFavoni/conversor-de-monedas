using conversor_de_monedas.Data;
using conversor_de_monedas.Data.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace conversor_de_monedas.Services
{
    public class MonedaServices
    {
        private readonly ConversorContext _context;
        public MonedaServices(ConversorContext context)
        {
            _context = context;
        }

        public List<Moneda> GetMonedas()
        {
            return _context.Monedas.ToList();
        }

        public Moneda GetMoneda(int id)
        {
            return _context.Monedas.SingleOrDefault(c => c.Id == id);
        }


        public bool DeleteMoneda(int id)
        {
            Moneda MonedaToDelete = GetMoneda(id);
            if (MonedaToDelete != null)
            {
                _context.Monedas.Remove(MonedaToDelete);
                _context.SaveChanges();
                return true;

            }
            return false;

        }

       

        public double Intercambio(User usuario, Moneda MonedaOrigen, Moneda MonedaDestino, int Cantidad ) 
        {
            double resultado;
            int tirosmax = usuario.Suscripcion.TirosMax;
            

            if (usuario.Tiros <= tirosmax)
            {
                resultado = (Cantidad * MonedaOrigen.valor) * MonedaDestino.valor;

                usuario.Tiros = usuario.Tiros + 1;

                _context.Users.Update(usuario);

            }
            else resultado = 9999.9999;

            Conversion interc = new Conversion()
            {
                
                IdMonedaOrigen = MonedaOrigen.Id,
                
                IdMonedaDestino = MonedaDestino.Id,
                
                IdUser = usuario.Id,
                fecha = DateTime.Now,
            };

            _context.Conversion.Add(interc);
            _context.SaveChanges();


            return resultado;
        }





    }

}
