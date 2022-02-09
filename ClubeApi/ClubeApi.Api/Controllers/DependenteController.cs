using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.ApplicationServices;
using ClubeApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClubeApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DependenteController : Controller
    {
        //Atributo para injeção de dependência do serviço da aplicação
        private readonly IApplicationServiceDependente applicationServiceDependente;

        //Construtor
        public DependenteController(IApplicationServiceDependente applicationServiceDependente)
        {
            this.applicationServiceDependente = applicationServiceDependente;
        }

        // GET: Listar dependentes
        [HttpGet]
        public ActionResult<IEnumerable<Dependente>> GetAll()
        {
            try
            {
                return Ok(applicationServiceDependente.GetAll());
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

        // GET: Selecionar dependente por ID
        [HttpGet("{id}")]
        public ActionResult<Dependente> GetById(int id)
        {
            try
            {
                Dependente dependente = applicationServiceDependente.GetById(id);
                if (dependente == null)
                {
                    var result = new
                    {
                        message = "O dependente buscado não foi encontrado",
                    };
                    return BadRequest(JsonConvert.SerializeObject(result));
                }
                else
                    return Ok(dependente);
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

        // POST: Cadastrar dependente
        [HttpPost]
        public ActionResult Add([FromBody] DependenteDTO dependenteDTO)
        {
            try
            {
                int resultado = applicationServiceDependente.Add(dependenteDTO);

                if(resultado == 1)
                {
                    var result = new
                    {
                        message = "Dependente cadastrado com sucesso",
                    };
                    return Ok(JsonConvert.SerializeObject(result));
                }
                else
                {
                    var result = new
                    {
                        message = "O dependente informado já consta na base de dados",
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

        // PUT: Atualizar dependente
        [HttpPut]
        public ActionResult Update([FromBody] DependenteDTO dependenteDTO)
        {
            try
            {
                applicationServiceDependente.Update(dependenteDTO);
                var result = new
                {
                    message = "Dependente atualizado com sucesso",
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

        // DELETE: Deletar dependente
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                int resultado = applicationServiceDependente.Delete(id);
                if(resultado == 1)
                {
                    var result = new
                    {
                        message = "Dependente deletado com sucesso",
                    };
                    return Ok(JsonConvert.SerializeObject(result));
                }
                else
                {
                    var result = new
                    {
                        message = "Ocorreu um erro na exclusão do item",
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
    }
}
