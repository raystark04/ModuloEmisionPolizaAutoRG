using FluentValidation;
using ModuloEmisionPolizaAuto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloEmisionPolizaAuto.Application.Handlers.Commands.CrearCliente
{
    public class CrearClienteValidator : AbstractValidator<CrearClienteCommand>
    {
       public CrearClienteValidator()
        {
            RuleFor(x => x.NombreCompleto)
                .NotEmpty().WithMessage("El nombre completo es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre completo no puede exceder los 100 caracteres.");
            RuleFor(x => x.NumeroIdentificacion)
                .NotEmpty().WithMessage("El número de identificación es obligatorio.")
                .MaximumLength(20).WithMessage("El número de identificación no puede exceder los 20 caracteres.");
            RuleFor(x => x.CorreoElectronico)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .EmailAddress().WithMessage("El correo electrónico no es válido.");
            RuleFor(x => x.Telefono)
                .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .MaximumLength(15).WithMessage("El teléfono no puede exceder los 15 caracteres.");
        }
    }
}
