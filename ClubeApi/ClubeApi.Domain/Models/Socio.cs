namespace ClubeApi.Domain.Models
{
    public class Socio : Pessoa
    {
        //Declaração de atributos
        public int NumeroCartao { get; set; }
        public String Telefone { get; set; }
        public String Cep { get; set; }
        public String Uf { get; set; }
        public String Cidade { get; set; }
        public String Bairro { get; set; }
        public String Logradouro { get; set; }
        public Categoria Categoria { get; set; }
        public List<Mensalidade> Mensalidades { get; set; }
        public List<Dependente>? Dependentes { get; set; }
    }
}
