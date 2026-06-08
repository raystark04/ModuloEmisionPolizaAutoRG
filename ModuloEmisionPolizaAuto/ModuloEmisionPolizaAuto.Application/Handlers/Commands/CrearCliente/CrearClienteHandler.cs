using FluentValidation;
using ModuloEmisionPolizaAuto.Application.DTOs;
using ModuloEmisionPolizaAuto.Application.Interfaces;
using ModuloEmisionPolizaAuto.Domain.Entities;

namespace ModuloEmisionPolizaAuto.Application.Handlers.Commands.CrearCliente;

public class CrearClienteHandler(IGenericInterface clientesRepository, IValidator<CrearClienteCommand> validador)
{
    private readonly IGenericInterface _clientesRepository = clientesRepository;
    private readonly IValidator<CrearClienteCommand> _validador = validador;

    public async Task<Cliente> Handle(CrearClienteCommand command, CancellationToken none)
    {
        var resultadoValidacion = await _validador.ValidateAsync(command);

        if (!resultadoValidacion.IsValid)
            throw new Exception("Error al validar el comando");

        var cliente = new Cliente
        {
            NombreCompleto = command.NombreCompleto,
            NumeroIdentificacion = command.NumeroIdentificacion,
            CorreoElectronico = command.CorreoElectronico,
            Telefono = command.Telefono
        };

        var ClienteCreado = await _clientesRepository.CrearClientesAsync(cliente);

        return ClienteCreado;

    } 
}
