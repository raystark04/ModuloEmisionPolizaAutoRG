using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ModuloEmisionPolizaAuto.Application.Handlers.Commands.CrearCliente;
using ModuloEmisionPolizaAuto.Application.Handlers.Commands.CrearPoliza;
using ModuloEmisionPolizaAuto.Application.Handlers.Commands.ObtenerCliente;
using ModuloEmisionPolizaAuto.Application.Handlers.Commands.ObtenerCobertura;
using ModuloEmisionPolizaAuto.Application.Handlers.Commands.ObtenerPoliza;
using ModuloEmisionPolizaAuto.Application.Handlers.Commands.ObtenerPolizaId;
using ModuloEmisionPolizaAuto.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<CrearClienteHandler>();
builder.Services.AddScoped<CrearPolizaHandler>();
builder.Services.AddScoped<ObtenerClienteHandler>();
builder.Services.AddScoped<ObtenerCobeturaHandler>();
builder.Services.AddScoped<ObtenerPolizasHandler>();
builder.Services.AddScoped<ObtenerPolizasIdHandler>();
builder.Services.AddValidatorsFromAssemblyContaining<CrearClienteValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CrearPolizaValidator>();


// Configurar la cadena de conexión a la base de datos
builder.Services.AddDbContext<DbContext>(options => 
{ 
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexionSQL"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseStaticFiles();

app.UseAuthorization();

//app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
