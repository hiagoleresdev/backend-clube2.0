using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.ApplicationServices;
using ClubeApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClubeApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocioController : Controller
    {
        //Atributo para injeção de dependência do serviço da aplicação
        private readonly IApplicationServiceSocio applicationServiceSocio;

        //Construtor
        public SocioController(IApplicationServiceSocio applicationServiceSocio)
        {
            this.applicationServiceSocio = applicationServiceSocio;
        }

        // GET: Listar sócios
        [HttpGet]
        public ActionResult<IEnumerable<Socio>> GetAll()
        {
            try
            {
                return Ok(applicationServiceSocio.GetAll());
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

        // GET: Selecionar sócio por ID
        [HttpGet("{id}")]
        public ActionResult<Socio> GetById(int id)
        {
            try
            {
                Socio socio = applicationServiceSocio.GetById(id);
                if (socio == null)
                {
                    var result = new
                    {
                        message = "O(A) sócio(a) buscado(a) não foi encontrado",
                    };
                    return BadRequest(JsonConvert.SerializeObject(result));
                }
                else
                    return Ok(socio);
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

        // POST: Cadastrar sócio
        [HttpPost]
        public ActionResult Add([FromBody] SocioDTO socioDTO)
        {
            try
            {
                int resultado = applicationServiceSocio.Add(socioDTO);
                
                if(resultado == 1)
                {
                    var result = new
                    {
                        message = "Sócio(a) cadastrado(a) com sucesso",
                    };
                    return Ok(JsonConvert.SerializeObject(result));
                }
                else
                {
                    var result = new
                    {
                        message = "O(A) sócio(a) infromado(a) já consta na base de dados",
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

        // PUT: Atualizar sócio
        [HttpPut]
        public ActionResult Update([FromBody] SocioDTO socioDTO)
        {
            try
            {
                applicationServiceSocio.Update(socioDTO);
                var result = new
                {
                    message = "Sócio(a) atualizado(a) com sucesso",
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

        // DELETE: Deletar sócio
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            { 
                applicationServiceSocio.Delete(id);
                var result = new
                {
                    message = "Sócio(a) deletado(a) com sucesso",
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
    }
}
