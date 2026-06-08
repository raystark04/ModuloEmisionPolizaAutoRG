using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloEmisionPolizaAuto.Application.DTOs
{
    public class CrearClienteCommand
    {
        public string NombreCompleto { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
    }
}
