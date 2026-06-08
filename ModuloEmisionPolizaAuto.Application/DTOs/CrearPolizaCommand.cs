namespace ModuloEmisionPolizaAuto.Application.DTOs
{
    public class CrearPolizaCommand
    {
            public int ClienteId { get; set; }

            public VehiculoRequest Vehiculo { get; set; } = new();

            public List<int> CoberturasIds { get; set; } = [];
    }
    public class VehiculoRequest
    {
            public string Placa { get; set; } = string.Empty;
            public string Marca { get; set; } = string.Empty;
            public string Modelo { get; set; } = string.Empty;
            public int Anio { get; set; }
            public decimal ValorComercial { get; set; }
    }

}
