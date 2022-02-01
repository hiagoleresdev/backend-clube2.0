namespace ClubeApi.Domain
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public int Meses { get; set; }
        public List<Socio> Socios { get; set; }  

    }
}
