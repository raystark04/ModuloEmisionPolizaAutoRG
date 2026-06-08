using Microsoft.EntityFrameworkCore;
using ModuloEmisionPolizaAuto.Application.DTOs;
using ModuloEmisionPolizaAuto.Application.Interfaces;
using ModuloEmisionPolizaAuto.Domain.Entities;
using ModuloEmisionPolizaAuto.Infrastructure.Persistence;

namespace ModuloEmisionPolizaAuto.Infrastructure.Repositories
{
    public class GenericRepository(Dbcontext context) : IGenericInterface
    {
        private readonly Dbcontext _context = context;

        public async Task<Cliente> CrearClientesAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);

            await _context.SaveChangesAsync();

            return cliente;
        }
        public async Task<Poliza> CrearPolizaAsync(CrearPolizaCommand command)
        {
            // Crear vehículo

            var vehiculo = new Vehiculo
            {
                ClienteId = command.ClienteId,
                Placa = command.Vehiculo.Placa,
                Marca = command.Vehiculo.Marca,
                Modelo = command.Vehiculo.Modelo,
                Anio = command.Vehiculo.Anio,
                ValorComercial = (double)command.Vehiculo.ValorComercial
            };

            _context.Vehiculos.Add(vehiculo);

            await _context.SaveChangesAsync();

            // Obtener coberturas

            var coberturas = await _context.Coberturas
                .Where(c => command.CoberturasIds.Contains(c.Id))
                .ToListAsync();

            // Calcular prima

            var primaTotal = coberturas.Sum(x => x.MontoCobertura);

            // Generar número de póliza
            string numeroPoliza = $"AU-{DateTime.Now:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 5).ToUpper()}";

            // Crear póliza

            var poliza = new Poliza
            {
                NumeroPoliza = numeroPoliza,
                VehiculoId = vehiculo.Id,
                FechaEmision = DateTime.Now,
                SumaAsegurada = (double)command.Vehiculo.ValorComercial,
                PrimaTotal = primaTotal
            };

            _context.Polizas.Add(poliza);

            await _context.SaveChangesAsync();

            // Crear relaciones

            foreach (var cobertura in coberturas)
            {
                _context.PolizaCoberturas.Add(
                    new PolizaCobertura
                    {
                        PolizaId = poliza.Id,
                        CoberturaId = cobertura.Id
                    });
            }

            await _context.SaveChangesAsync();

            return poliza;
        }

        public async Task<List<Cliente>> ObtenerClientesAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<List<Cobertura>> ObtenerCoberturasAsync()
        {
            return await _context.Coberturas.ToListAsync();
        }

        public async Task<List<Poliza>> ObtenerPolizasAsync()
        {
            return await _context.Polizas.ToListAsync();

        }

        public async Task<ObtenerPolizaIdDTO?> ObtenerPolizaPorIdAsync(int id)
        {
            var poliza = await _context.Polizas
            .FirstOrDefaultAsync(p => p.Id == id);

            if (poliza == null)
                return null;

            var vehiculo = await _context.Vehiculos
                .FirstOrDefaultAsync(v => v.Id == poliza.VehiculoId);

            if (vehiculo == null)
                return null;

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Id == vehiculo.ClienteId);


            return new ObtenerPolizaIdDTO
            {
                Id = poliza.Id,
                NumeroPoliza = poliza.NumeroPoliza,
                NombreCliente = cliente?.NombreCompleto ?? "",
                Placa = vehiculo?.Placa ?? "",
                Marca = vehiculo?.Marca ?? "",
                Modelo = vehiculo?.Modelo ?? "",
                PrimaTotal = (decimal)poliza.PrimaTotal,
                SumaAsegurada = (decimal)poliza.SumaAsegurada,
                FechaEmision = poliza.FechaEmision
            };
        }
    }
}
