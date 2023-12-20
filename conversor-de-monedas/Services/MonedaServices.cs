using conversor_de_monedas.Data;
using conversor_de_monedas.Data.Entities;
using conversor_de_monedas.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace conversor_de_monedas.Services
{
    public class MonedaServices
    {
        private readonly ConversorContext _context;
        private readonly UserServices _userServices;
        public MonedaServices(ConversorContext context, UserServices userServices)
        {
            _context = context;
            _userServices = userServices;
        }

        public List<Moneda> GetMonedas()
        {
            return _context.Monedas.ToList();
        }

        public Moneda GetMonedaById(int id)
        {
            return _context.Monedas.SingleOrDefault(c => c.Id == id);
        }

        public Moneda GetMonedaByName(string name)
        {
            Moneda moneda = _context.Monedas.SingleOrDefault(c => c.Sigla == name);
            return moneda;
        }

        public bool DeleteMoneda(int id)
        {
            Moneda MonedaToDelete = GetMonedaById(id);
            if (MonedaToDelete != null)
            {
                _context.Monedas.Remove(MonedaToDelete);
                _context.SaveChanges();
                return true;

            }
            return false;

        }



        public List<string> GetListMonedas()
        {
            return _context.Monedas.Select(c => c.Sigla).ToList();
        }

        public double Intercambio(int usuarioID, string MonedaOrigenName, string MonedaDestinoName, int Cantidad)
        {
            //Falta hacer traer el usuario desde el JWT.
            Moneda MonedaOrigen = GetMonedaByName(MonedaOrigenName);
            Moneda MonedaDestino = GetMonedaByName(MonedaDestinoName);
            User usuario = _userServices.GetUser(usuarioID);
            double resultado;
            Suscripcion suscripcion = _context.suscripciones.SingleOrDefault(c => c.Id == usuario.SuscripcionId);
            int tirosmax = suscripcion.TirosMax;




            if (usuario.Tiros < tirosmax)
            {
                resultado = (Cantidad * MonedaOrigen.valor) * MonedaDestino.valor;

                usuario.Tiros = usuario.Tiros + 1;

                _context.Users.Update(usuario);

            }
            else resultado = -99;

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

        public void CreateMoneda(CreateAndUpdateMonedaDTO dto)
        {
            Moneda MonedaNew = new Moneda()
            {
                valor = dto.valor,
                Sigla = dto.sigla,
                Name = dto.name,
                
            };
            _context.Monedas.Add(MonedaNew);
            _context.SaveChanges();
        }

        public void UpdateMoneda(CreateAndUpdateMonedaDTO dto, int MonedaId)
        {
            Moneda? monedaUpdate = _context.Monedas.SingleOrDefault(moneda => moneda.Id == MonedaId);
            if (monedaUpdate is not null)
            {
                monedaUpdate.valor = dto.valor;
                monedaUpdate.Sigla = dto.sigla;
                monedaUpdate.Name = dto.name;
                _context.SaveChanges();
            }

        }


    }
}

