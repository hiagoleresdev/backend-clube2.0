namespace ClubeApi.Domain.Models
{
    public class Categoria
    {
        //Declaração de atributos
        public int Id { get; set; }
        public string Tipo { get; set; }
        public int Meses { get; set; }
        public List<Socio> Socios { get; set; }
    }
}