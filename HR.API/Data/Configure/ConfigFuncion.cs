using HR.API.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.API.Data.Configure
{
    public class ConfigFuncion
    {
        public ConfigFuncion(EntityTypeBuilder<Funcion> BuilderFuncion)
        {
            BuilderFuncion.HasData(
                          new Funcion
                          {
                              Id = 1,
                              Descripcion = "Instalador",
                          }) ;
            BuilderFuncion.HasData(
                         new Funcion
                         {
                             Id = 2,
                             Descripcion = "Service",
                         });
            BuilderFuncion.HasData(
                         new Funcion
                         {
                             Id = 3,
                             Descripcion = "Red",
                         });
        }
    }
}
