using System.Security.Cryptography.X509Certificates;

namespace ModuloEmisionPolizaAuto.Models
{
    public class Poliza
    {
        public int Id { get; set; }

        public string NumeroPoliza { get; set; }

        public int VehiculoId { get; set; }

        public DateTime FechaEmision { get; set; }

        public double SumaAsegurada { get; set; }

        public double PrimaTotal { get; set; }
    }
}
