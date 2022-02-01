namespace ClubeApi.Domain
{
    public class Mensalidades
    {

        public int Id { get; set; }
        public DateTime DataVencimento { get; set; }
        public double ValorInicial { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int Juros { get; set; }
        public double? ValorFinal { get; set; }
        public bool Quitada { get; set; }
        public Socio Socio { get; set; } 

    }
}
