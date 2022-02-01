namespace ClubeApi.Domain
{
    public class Dependente
    {
        public int NumeroCartao { get; set; }
        public string Parentesco { get; set; }
        public Socio Socio { get; set; }

    }
}
