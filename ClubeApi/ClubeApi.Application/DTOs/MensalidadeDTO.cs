namespace ClubeApi.Application.DTOs
{
    public class MensalidadeDTO
    {
        //Declaração dos atributos
        public int Id { get; set; }
        public DateTime DataVencimento { get; set; }
        public double ValorInicial { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int Juros { get; set; }
        public double? ValorFinal { get; set; }
        public bool Quitada { get; set; }
        public int FkSocio { get; set; }
    }
}
