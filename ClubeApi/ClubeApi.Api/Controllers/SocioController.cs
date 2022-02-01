using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.ApplicationServices;
using ClubeApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;

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
                return BadRequest($"Erro: {ex.Message}");
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
                    return NotFound();
                else
                    return Ok(socio);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // POST: Cadastrar sócio
        [HttpPost]
        public ActionResult Add([FromBody] SocioDTO socioDTO)
        {
            try
            {
                applicationServiceSocio.Add(socioDTO);
                return Ok("Sócio cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // PUT: Atualizar sócio
        [HttpPut]
        public ActionResult Update([FromBody] SocioDTO socioDTO)
        {
            try
            {
                applicationServiceSocio.Update(socioDTO);
                return Ok("Sócio atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // DELETE: Deletar sócio
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            { 
                applicationServiceSocio.Delete(id);
                return Ok("Sócio deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
