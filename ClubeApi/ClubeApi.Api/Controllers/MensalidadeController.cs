using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.ApplicationServices;
using ClubeApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClubeApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MensalidadeController : Controller
    {
        //Atributo para injeção de dependência do serviço da aplicação
        private readonly IApplicationServiceMensalidade applicationServiceMensalidade;

        //Construtor
        public MensalidadeController(IApplicationServiceMensalidade applicationServiceMensalidade)
        {
            this.applicationServiceMensalidade = applicationServiceMensalidade;
        }

        // GET: Listar mensalidades
        [HttpGet]
        public ActionResult<IEnumerable<Mensalidade>> GetAll()
        {
            try
            {
                return Ok(applicationServiceMensalidade.GetAll());
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

        // GET: Selecionar mensalidade por ID
        [HttpGet("{id}")]
        public ActionResult<Mensalidade> GetById(int id)
        {
            try
            {
                Mensalidade mensalidade = applicationServiceMensalidade.GetById(id);
                if (mensalidade == null)
                {
                    var result = new
                    {
                        message = "A mensalidade buscada não foi encontrada",
                    };
                    return BadRequest(JsonConvert.SerializeObject(result));
                }
                else
                    return Ok(mensalidade);
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

        // POST: Cadastrar mensalidade
        [HttpPost]
        public ActionResult Add([FromBody] MensalidadeDTO mensalidadeDTO)
        {
            try
            {
                applicationServiceMensalidade.Add(mensalidadeDTO);
                var result = new
                {
                    message = "Mensalidade cadastrada com sucesso",
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

        // PUT: Atualizar mensalidade
        [HttpPut]
        public ActionResult Update([FromBody] MensalidadeDTO mensalidadeDTO)
        {
            try
            {
                applicationServiceMensalidade.Update(mensalidadeDTO);
                var result = new
                {
                    message = "Mensalidade atualizada com sucesso",
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

        // DELETE: Deletar mensalidade
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                applicationServiceMensalidade.Delete(id);
                var result = new
                {
                    message = "Mensalidade deletada com sucesso",
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
