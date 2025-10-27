namespace api_crud_mascota.Models
{
    public class Mascota
    {
        public int Id { get; set; } 
        public string Nombre { get; set; } 
        public string Raza { get; set; } 
        public string Color { get; set; } 
        public string Edad { get; set; } 
        public string Peso { get; set; } 
        public DateTime FechaCreacion { get; set; } 

    }
}
