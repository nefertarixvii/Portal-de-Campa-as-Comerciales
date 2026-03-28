namespace PortalCampanas.Models
{
    public class Campania
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double DescuentoPct { get; set; }
        public string Canal { get; set; }
        public string Descripcion { get; set; }
    }
}