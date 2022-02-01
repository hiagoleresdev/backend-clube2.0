namespace ClubeApi.Domain.Models
{
    public class Dependente : Pessoa
    {
        //Declaração de atributos
        public int NumeroCartao { get; set; }
        public string Parentesco { get; set; }
        public Socio Socio { get; set; }
    }
}
