using HR.API.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.API.Data.Configure
{
    public class ConfigMaterial
    {
        public ConfigMaterial (EntityTypeBuilder<Material> BuilderMaterial)
        {

            BuilderMaterial.HasData(
                           new Material
                           {
                               Id = 1,
                               Descripcion = "Conector RG59",
                               Nombre = "RG 59",
                           });
        }
    }
}
