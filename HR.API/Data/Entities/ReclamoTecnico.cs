namespace HR.API.Data.Entities
{
    public class ReclamoTecnico
    {
        public int ReclamoId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
       
        public Reclamo Reclamo { get; set; }
    }
}
