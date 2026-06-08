using ModuloEmisionPolizaAuto.Application.Interfaces;
using ModuloEmisionPolizaAuto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloEmisionPolizaAuto.Application.Handlers.Commands.ObtenerPoliza
{
    public class ObtenerPolizasHandler(IGenericInterface genericRepository)
    {
        private readonly IGenericInterface _obtenerpolizaRepository = genericRepository;

        public async Task<List<Poliza>> Handle()
        {
            return await _obtenerpolizaRepository.ObtenerPolizasAsync();
        }
    }
}
