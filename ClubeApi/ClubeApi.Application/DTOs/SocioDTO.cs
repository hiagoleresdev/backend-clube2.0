namespace ClubeApi.Application.DTOs
{
    public class SocioDTO : PessoaDTO
    {
        //Declaração de atributos
        public int NumeroCartao { get; set; }
        public String Telefone { get; set; }
        public String Cep { get; set; }
        public String Uf { get; set; }
        public String Cidade { get; set; }
        public String Bairro { get; set; }
        public String Logradouro { get; set; }
        public int FkCategoria { get; set; }
    }
}
