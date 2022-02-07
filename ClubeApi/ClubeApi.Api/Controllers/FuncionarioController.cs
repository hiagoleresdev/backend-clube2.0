using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.ApplicationServices;
using ClubeApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClubeApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : Controller
    {
        //Atributo para injeção de dependência do serviço da aplicação
        private readonly IApplicationServiceFuncionario applicationServiceFuncionario;

        //Construtor
        public FuncionarioController(IApplicationServiceFuncionario applicationServiceFuncionario)
        {
            this.applicationServiceFuncionario = applicationServiceFuncionario;
        }

        // GET: Selecionar funcionário por ID
        [HttpGet("{id}")]
        public ActionResult<Funcionario> GetById(int id)
        {
            try
            {
                Funcionario funcionario = applicationServiceFuncionario.GetById(id);
                if(funcionario == null)
                {
                    var result = new
                    {
                        message = "O funcionário buscado não foi encontrada",
                    };
                    return NotFound(JsonConvert.SerializeObject(result));
                }
                else
                    return Ok(funcionario);
            }
            catch (Exception ex)
            {
                var result = new
                {
                    message = $"Erro: {ex.Message}",
                };
                return BadRequest(JsonConvert.SerializeObject(result));
            }
        }

        // POST: Cadastrar funcionário
        [HttpPost]
        public ActionResult Add([FromBody] FuncionarioDTO FuncionarioDTO)
        {
            try
            {
                int resultado = applicationServiceFuncionario.Add(FuncionarioDTO);
                
                if(resultado == 1)
                {
                    var result = new
                    {
                        message = "Funcionário(a) cadastrado(a) com sucesso",
                    };
                    return Ok(JsonConvert.SerializeObject(result));
                }
                else
                {
                    var result = new
                    {
                        message = "O(A) funcionário(a) informado(a) já consta na base de dados",
                    };
                    return Conflict(JsonConvert.SerializeObject(result));
                }
            }
            catch (Exception ex)
            {
                var result = new
                {
                    message = $"Erro: {ex.Message}",
                };
                return BadRequest(JsonConvert.SerializeObject(result));
            }
        }

        // PUT: Atualizar funcionário
        [HttpPut]
        public ActionResult Update([FromBody] FuncionarioDTO funcionarioDTO)
        {
            try
            {
                applicationServiceFuncionario.Update(funcionarioDTO);
                var result = new
                {
                    message = "Funcionário(a) atualizado(a) com sucesso",
                };
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (Exception ex)
            {
                var result = new
                {
                    message = $"Erro: {ex.Message}",
                };
                return BadRequest(JsonConvert.SerializeObject(result));
            }
        }

        // DELETE: Deletar funcionário
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                applicationServiceFuncionario.Delete(id);
                var result = new
                {
                    message = "Funcionário(a) deletado(a) com sucesso",
                };
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (Exception ex)
            {
                var result = new
                {
                    message = $"Erro: {ex.Message}",
                };
                return BadRequest(JsonConvert.SerializeObject(result));
            }
        }

        // GET: Validar login
        [HttpGet("{usuario}/{senha}")]
        public ActionResult Validate(string usuario, string senha)
        {
            try
            {
                if (applicationServiceFuncionario.Validate(usuario, senha) == 1)
                {
                    var result = new
                    {
                        message = "Login efetuado com sucesso",
                    };
                    return Ok(JsonConvert.SerializeObject(result));
                }
                else
                {
                    var result = new
                    {
                        message = "O usuário e ou senha informados não existem",
                    };
                    return NotFound(JsonConvert.SerializeObject(result));
                }
            }
            catch (Exception ex)
            {
                var result = new
                {
                    message = $"Erro: {ex.Message}",
                };
                return BadRequest(JsonConvert.SerializeObject(result));
            }
        }
    }
}
