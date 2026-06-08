using ModuloEmisionPolizaAuto.Application.Interfaces;
using ModuloEmisionPolizaAuto.Domain.Entities;

namespace ModuloEmisionPolizaAuto.Application.Handlers.Commands.ObtenerCliente;

public class ObtenerClienteHandler(IGenericInterface genericRepository)
{
    private readonly IGenericInterface _obtenerclienteRepository = genericRepository;

    public async Task<List<Cliente>> Handle()
    {
        return await _obtenerclienteRepository.ObtenerClientesAsync();
    }
}
