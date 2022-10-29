namespace HR.API.Data.Entities
{
    public class ReclamoMaterial
    {
        public int ReclamoId { get; set; }
        public int MaterialId { get; set; }
        public Reclamo Reclamo { get; set; }
        public Material Material { get; set; }
        public int? CantidadUsada { get; set; }
    }
}
