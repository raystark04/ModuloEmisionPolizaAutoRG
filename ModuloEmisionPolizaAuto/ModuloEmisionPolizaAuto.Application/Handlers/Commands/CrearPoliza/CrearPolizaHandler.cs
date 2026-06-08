using FluentValidation;
using ModuloEmisionPolizaAuto.Application.DTOs;
using ModuloEmisionPolizaAuto.Application.Interfaces;
using ModuloEmisionPolizaAuto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloEmisionPolizaAuto.Application.Handlers.Commands.CrearPoliza
{
    public class CrearPolizaHandler(IGenericInterface genericRepository, IValidator<CrearPolizaCommand> validador)
    {
        private readonly IGenericInterface _genericRepository = genericRepository;
        private readonly IValidator<CrearPolizaCommand> _validador = validador;

        public async Task<Poliza> Handle(CrearPolizaCommand command, CancellationToken none)
        {
            var resultadoValidacion = await _validador.ValidateAsync(command);

            if (!resultadoValidacion.IsValid)
                throw new Exception("Error al validar el comando");

            var PolizaCreada = await _genericRepository.CrearPolizaAsync(command);

            return PolizaCreada;

        }
    }
}
