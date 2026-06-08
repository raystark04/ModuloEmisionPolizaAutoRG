using ModuloEmisionPolizaAuto.Application.DTOs;
using ModuloEmisionPolizaAuto.Application.Interfaces;

namespace ModuloEmisionPolizaAuto.Application.Handlers.Commands.ObtenerPolizaId;

public class ObtenerPolizasIdHandler
{
    private readonly IGenericInterface _genericRepository;

    public ObtenerPolizasIdHandler(IGenericInterface genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<ObtenerPolizaIdDTO> Handle(int id)
    {
        return await _genericRepository.ObtenerPolizaPorIdAsync(id);
    }
}
