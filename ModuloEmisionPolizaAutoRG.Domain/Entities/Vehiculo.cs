namespace ModuloEmisionPolizaAuto.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int Anio { get; set; }
        public double ValorComercial { get; set; }
        public int ClienteId { get; set; }
    }
}
