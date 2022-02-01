namespace ClubeApi.Application.DTOs
{
    public class DependenteDTO : PessoaDTO
    {
        //Declaração de atributos
        public int NumeroCartao { get; set; }
        public string Parentesco { get; set; }
        public int FkSocio{ get; set; }
    }
}
