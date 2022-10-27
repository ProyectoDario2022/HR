using HR.API.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.API.Data.Configure
{
    public class ConfigReclamoType
    {
        public ConfigReclamoType(EntityTypeBuilder<ReclamoType> BuilderReclamoType)
        {

            BuilderReclamoType.HasData(
                           new ReclamoType
                           {
                               Id = 1,
                               Descripcion = "Instalacion",
                           });
            BuilderReclamoType.HasData(
                          new ReclamoType
                          {
                              Id = 2,
                              Descripcion = "Service",
                          });
            BuilderReclamoType.HasData(
                         new ReclamoType
                         {
                             Id =3,
                             Descripcion = "Red",
                         });
            BuilderReclamoType.HasData(
                        new ReclamoType
                        {
                            Id = 4,
                            Descripcion = "Reinstalacion",
                        });
        }
    }
}
