using conversor_de_monedas.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace conversor_de_monedas.Data
{
    public class ConversorContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Suscripcion> suscripciones { get; set; }
        public DbSet<Moneda> Monedas { get; set; }
        
        public DbSet<Conversion> Conversion { get; set; }


        public ConversorContext(DbContextOptions<ConversorContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Moneda Dolar = new Moneda()
            {
                Id = 2,
                Name = "Dolar EEUU",
                Sigla = "USD",
                valor = 1,


            };
            Moneda Peso = new Moneda()
            {
                Id = 1,
                Name = "Peso Argentino",
                Sigla = "ARS",
                valor = 0.002,

                
            };

            Moneda Euro = new Moneda()
            {
                Id = 3,
                Name = "Euro",
                Sigla = "EUR",
                valor = 1.09,
            };

            Moneda Corona = new Moneda()
            {
                Id = 4,
                Name = "Corona Checa",
                Sigla = "KC",
                valor = 0.043,
            };


            Suscripcion Comun = new Suscripcion()
            {
                Id = 1,
                Name = "Comun",
                TirosMax = 5,

            };

            Suscripcion Premiun = new Suscripcion()
            {
                Id = 2,
                Name = "Premiun",
                TirosMax = 10,

            };

            Suscripcion VIP = new Suscripcion()
            {
                Id = 3,
                Name = "VIP",
                TirosMax = 5000,
            };


            User Lautaro = new User()
            {
                Id = 1,
                UserName = "Lautaro",
                Password = "password",
                Email = "email@gmail.com",
                Tiros = 0,
                Role = "ADMIN",
                
                SuscripcionId = Comun.Id,
                

            };

            User jose = new User()
            {
                Id = 2,
                UserName = "Jose",
                Password = "password",
                Email = "email2@gmail.com",
                Tiros = 0,
                Role = "Free",
                SuscripcionId = Premiun.Id,
               

            };

            Conversion conversion1 = new Conversion()
            {
                Id = 1,
                IdMonedaOrigen= 1,
                IdMonedaDestino = 2,
                IdUser = 1,
                fecha= DateTime.Now,


            };

            modelBuilder.Entity<User>()
            .HasOne(c => c.Suscripcion)
            .WithMany()
            .HasForeignKey(c => c.SuscripcionId);

            //modelBuilder.Entity<Conversion>()
            //.HasOne(c => c.MonedaOrigen)
            //.WithMany()
            //.HasForeignKey(c => c.IdMonedaOrigen);

            //modelBuilder.Entity<Conversion>()
            //    .HasOne(c => c.MonedaDestino)
            //    .WithMany()
            //    .HasForeignKey(c => c.IdMonedaDestino);



            modelBuilder.Entity<User>().HasData(jose,Lautaro);

            modelBuilder.Entity<Suscripcion>().HasData(Comun, Premiun);

            modelBuilder.Entity<Moneda>().HasData(Peso, Dolar, Corona, Euro);

            modelBuilder.Entity<Conversion>().HasData(conversion1);


            base.OnModelCreating(modelBuilder);


        }
    }
}

