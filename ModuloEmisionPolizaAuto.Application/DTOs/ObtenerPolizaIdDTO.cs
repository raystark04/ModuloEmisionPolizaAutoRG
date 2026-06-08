using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloEmisionPolizaAuto.Application.DTOs
{
    public class ObtenerPolizaIdDTO
    {
        
            public int Id { get; set; }

            public string NumeroPoliza { get; set; } = string.Empty;

            public string NombreCliente { get; set; } = string.Empty;

            public string Placa { get; set; } = string.Empty;

            public string Marca { get; set; } = string.Empty;

            public string Modelo { get; set; } = string.Empty;

            public decimal PrimaTotal { get; set; }

            public decimal SumaAsegurada { get; set; }

            public DateTime FechaEmision { get; set; }
        
    }
}
