using FluentValidation;
using ModuloEmisionPolizaAuto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloEmisionPolizaAuto.Application.Handlers.Commands.CrearPoliza
{
    public class CrearPolizaValidator
     : AbstractValidator<CrearPolizaCommand>
    {
        public CrearPolizaValidator()
        {
            RuleFor(x => x.ClienteId)
                .GreaterThan(0);

            RuleFor(x => x.CoberturasIds)
                .NotEmpty();
        }
    }
}
