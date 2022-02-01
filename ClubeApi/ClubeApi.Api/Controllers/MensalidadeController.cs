using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.ApplicationServices;
using ClubeApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;

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
                return BadRequest($"Erro: {ex.Message}");
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
                    return NotFound();
                else
                    return Ok(mensalidade);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // POST: Cadastrar mensalidade
        [HttpPost]
        public ActionResult Add([FromBody] MensalidadeDTO mensalidadeDTO)
        {
            try
            {
                if (mensalidadeDTO == null)
                    return NotFound();

                applicationServiceMensalidade.Add(mensalidadeDTO);
                return Ok("Mensalidade cadastrada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // PUT: Atualizar mensalidade
        [HttpPut]
        public ActionResult Update([FromBody] MensalidadeDTO mensalidadeDTO)
        {
            try
            {
                applicationServiceMensalidade.Update(mensalidadeDTO);
                return Ok("Mensalidade atualizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // DELETE: Deletar mensalidade
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                applicationServiceMensalidade.Delete(id);
                return Ok("Mensalidade deletada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
