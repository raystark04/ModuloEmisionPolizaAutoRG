using ModuloEmisionPolizaAuto.Application.DTOs;
using ModuloEmisionPolizaAuto.Domain.Entities;

namespace ModuloEmisionPolizaAuto.Application.Interfaces
{
    public interface IGenericInterface
    {
        Task <Cliente> CrearClientesAsync(Cliente cliente);

        Task<Poliza> CrearPolizaAsync(CrearPolizaCommand command);

        Task<List<Cliente>> ObtenerClientesAsync();

        Task<List<Cobertura>> ObtenerCoberturasAsync();

        Task<List<Poliza>> ObtenerPolizasAsync();

        Task<ObtenerPolizaIdDTO?> ObtenerPolizaPorIdAsync(int id);
    }
}
