namespace ClubeApi.Domain.Models
{
    public class Funcionario : Pessoa
    {
        //Declaração de atributos
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}