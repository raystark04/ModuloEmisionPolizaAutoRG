using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloEmisionPolizaAuto.Domain.Entities;

namespace ModuloEmisionPolizaAuto.Infrastructure.Persistence
{
    public class Dbcontext(DbContextOptions<Dbcontext> options) : DbContext(options)
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Cobertura> Coberturas { get; set; }
        public DbSet<Poliza> Polizas { get; set; }
        public DbSet<PolizaCobertura> PolizaCoberturas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la entidad Cliente
            modelBuilder.Entity<Cliente>(tabla =>
            {
                tabla.HasKey(campo => campo.Id);

                tabla.Property(campo => campo.Id)
                .UseIdentityColumn()   //auto incrementable
                .ValueGeneratedOnAdd();

                tabla.Property(campo => campo.NombreCompleto)
                .IsRequired()
                .HasMaxLength(100);

                tabla.Property(campo => campo.NumeroIdentificacion)
                .IsRequired()
                .HasMaxLength(20);

                tabla.Property(campo => campo.CorreoElectronico)
                .HasMaxLength(50);

                tabla.Property(campo => campo.Telefono);

            });
            modelBuilder.Entity<Cliente>().ToTable("Clientes");

            // Configuración de la entidad Vehiculo
            modelBuilder.Entity<Vehiculo>(tabla =>
            {
                tabla.HasKey(campo => campo.Id);
                tabla.Property(campo => campo.Id)
                .UseIdentityColumn()   //auto incrementable
                .ValueGeneratedOnAdd();

                tabla.Property(campo => campo.Marca)
                .IsRequired()
                .HasMaxLength(50);

                tabla.Property(campo => campo.Modelo)
                .IsRequired()
                .HasMaxLength(100);

                tabla.Property(campo => campo.Placa)
                .IsRequired()
                .HasMaxLength(20);

                tabla.Property(campo => campo.Anio)
                .IsRequired();

                tabla.Property(campo => campo.ValorComercial)
                .IsRequired();

                tabla.HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(campo => campo.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Vehiculo>().ToTable("Vehiculos");


            // Configuración de la tabla Coberturas
            modelBuilder.Entity<Cobertura>(tabla =>
            {
                tabla.HasKey(campo => campo.Id);
                tabla.Property(campo => campo.Id)
                .UseIdentityColumn()   //auto incrementable
                .ValueGeneratedOnAdd();
                tabla.Property(campo => campo.TipoCobertura)
                .IsRequired()
                .HasMaxLength(100);

                tabla.Property(campo => campo.MontoCobertura)
                .IsRequired();
            });
            modelBuilder.Entity<Cobertura>().ToTable("Coberturas");


            // Configuración de la entidad Poliza

            modelBuilder.Entity<Poliza>(tabla =>
            {
                tabla.HasKey(campo => campo.Id);
                tabla.Property(campo => campo.Id)
                .UseIdentityColumn()   //auto incrementable
                .ValueGeneratedOnAdd();

                tabla.Property(campo => campo.NumeroPoliza)
                .IsRequired()
                .HasValueGenerator<GeneradorNumeroPolizaAU>();

                tabla.HasOne<Vehiculo>()
               .WithMany()
               .HasForeignKey(campo => campo.VehiculoId)
               .OnDelete(DeleteBehavior.Cascade);


                tabla.Property(campo => campo.FechaEmision)
                .IsRequired();

                tabla.Property(campo => campo.SumaAsegurada)
                .IsRequired();

                tabla.Property(campo => campo.PrimaTotal)
                .IsRequired();

            });
            modelBuilder.Entity<Poliza>().ToTable("Polizas");


            // Configuración de la tabla Polizas - Coberturas

            modelBuilder.Entity<PolizaCobertura>(tabla =>
            {

                tabla.HasKey(campo => campo.Id);
                tabla.Property(campo => campo.Id)
                .UseIdentityColumn()   //auto incrementable
                .ValueGeneratedOnAdd();

                tabla.HasOne<Poliza>()
                .WithMany()
                .HasForeignKey(campo => campo.PolizaId)
                .OnDelete(DeleteBehavior.Cascade);

                tabla.HasOne<Cobertura>()
                .WithMany()
                .HasForeignKey(campo => campo.CoberturaId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<PolizaCobertura>().ToTable("PolizasCoberturas");

        }


    }
}
