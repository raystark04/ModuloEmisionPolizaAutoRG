using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace ModuloEmisionPolizaAuto.Data
{
    public class GeneradorNumeroPolizaAU : ValueGenerator<string> 
    {
        public override bool GeneratesTemporaryValues => false;

        public override string Next(EntityEntry entry)
        {
            string prefijo = "AU";
            string anioActual = DateTime.Now.Year.ToString();
            string numeroPoliza = Guid.NewGuid().ToString().Substring(0, 5).ToUpper();

            return $"{prefijo}-{anioActual}-{numeroPoliza}";
            ;
        }
    }
}
