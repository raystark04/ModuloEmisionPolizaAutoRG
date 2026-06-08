using ModuloEmisionPolizaAuto.Application.Interfaces;
using ModuloEmisionPolizaAuto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloEmisionPolizaAuto.Application.Handlers.Commands.ObtenerCobertura
{
    public class ObtenerCobeturaHandler(IGenericInterface genericRepository)
    {
        private readonly IGenericInterface _obtenerCoberturaRepository = genericRepository;
        public async Task<List<Cobertura>> Handle()
        {
            return await _obtenerCoberturaRepository.ObtenerCoberturasAsync();
        }
    }
}
