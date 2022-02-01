using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.ApplicationServices;
using ClubeApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;

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
                return BadRequest($"Erro: {ex.Message}");
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
                    return NotFound();
                else
                    return Ok(dependente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // POST: Cadastrar dependente
        [HttpPost]
        public ActionResult Add([FromBody] DependenteDTO dependenteDTO)
        {
            try
            {
                applicationServiceDependente.Add(dependenteDTO);
                return Ok("Dependente cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // PUT: Atualizar dependente
        [HttpPut]
        public ActionResult Update([FromBody] DependenteDTO dependenteDTO)
        {
            try
            {
                applicationServiceDependente.Update(dependenteDTO);
                return Ok("Dependente atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // DELETE: Deletar dependente
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                applicationServiceDependente.Delete(id);
                return Ok("Dependente deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
