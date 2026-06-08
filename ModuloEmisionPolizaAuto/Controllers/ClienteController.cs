using Microsoft.AspNetCore.Mvc;
using ModuloEmisionPolizaAuto.Application.DTOs;
using ModuloEmisionPolizaAuto.Application.Handlers.Commands.CrearCliente;
using ModuloEmisionPolizaAuto.Application.Handlers.Commands.CrearPoliza;
using ModuloEmisionPolizaAuto.Application.Handlers.Commands.ObtenerCliente;
using ModuloEmisionPolizaAuto.Application.Handlers.Commands.ObtenerCobertura;
using ModuloEmisionPolizaAuto.Application.Handlers.Commands.ObtenerPoliza;
using ModuloEmisionPolizaAuto.Application.Handlers.Commands.ObtenerPolizaId;
using System.Reflection.Metadata;
namespace ModuloEmisionPolizaAuto.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController(CrearClienteHandler clienteHandler, CrearPolizaHandler polizasHandler,ObtenerClienteHandler _obtenerClienteHandler, ObtenerCobeturaHandler _obtenerCobeturaHandler, 
    ObtenerPolizasHandler _obtenerpolizaHandler, ObtenerPolizasIdHandler _obtenerpolizaIdHandler) : ControllerBase
{
    private readonly CrearClienteHandler _clientesHandler = clienteHandler;
    private readonly CrearPolizaHandler _polizasHandler = polizasHandler;
    private readonly ObtenerPolizasHandler _obtenerpolizaHandler = _obtenerpolizaHandler;
    private readonly ObtenerPolizasIdHandler _obtenerpolizaIdHandler = _obtenerpolizaIdHandler;

    [HttpPost("crear")]
    public async Task<IActionResult> CrearCliente(CrearClienteCommand command)
    {
        var resultado = await _clientesHandler.Handle(command, CancellationToken.None);
        if (resultado == null)
        {
            return BadRequest("No se pudo crear el cliente.");
        }
        return Ok(resultado);
    }

    [HttpPost("crear/poliza")]
    public async Task<IActionResult> CrearPoliza(CrearPolizaCommand command)
    {

        try
        {
            var resultado = await _polizasHandler.Handle(command, CancellationToken.None);

            return CreatedAtAction(
                nameof(CrearPoliza),
                new { id = resultado.Id },
                resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                mensaje = ex.Message
            });
        }
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerCliente()
    {

        var clientes = await _obtenerClienteHandler.Handle();

        return Ok(clientes);
    }

    [HttpGet("obtener/cobertura")]
    public async Task<IActionResult> ObtenerCoberturas()
    {
        var coberturas = await _obtenerCobeturaHandler.Handle();

        return Ok(coberturas);
    }

    [HttpGet("obtener/polizas")]
    public async Task<IActionResult> ObtenerPolizas()
    {
        var poliza = await _obtenerpolizaHandler.Handle();

        if (poliza == null)
        {
            return NotFound("Póliza no encontrada.");
        }

        return Ok(poliza);
    }

    [HttpGet("obtener/poliza/{id}")]
    public async Task<IActionResult> ObtenerPolizaPorId(int id)
    {
        var poliza = await _obtenerpolizaIdHandler.Handle(id);

        if (poliza == null)
        {
            return NotFound("Póliza no encontrada.");
        }

        return Ok(poliza);
    }


}