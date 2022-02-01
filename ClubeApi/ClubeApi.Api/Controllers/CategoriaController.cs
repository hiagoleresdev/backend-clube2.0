using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.ApplicationServices;
using ClubeApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClubeApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        //Atributo para injeção de dependência do serviço da aplicação
        private readonly IApplicationServiceCategoria applicationServiceCategoria;

        //Construtor
        public CategoriaController(IApplicationServiceCategoria applicationServiceCategoria)
        {
            this.applicationServiceCategoria = applicationServiceCategoria;
        }

        // GET: Listar categorias
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetAll()
        {
            try
            {
                return Ok(applicationServiceCategoria.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // GET: Selecionar categoria por ID
        [HttpGet("{id}")]
        public ActionResult<Categoria> GetById(int id)
        {
            try
            {
                Categoria categoria = applicationServiceCategoria.GetById(id);
                if (categoria == null)
                    return NotFound();
                else
                    return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // POST: Cadastrar categoria
        [HttpPost]
        public ActionResult Add([FromBody] CategoriaDTO categoriaDTO)
        {
            try
            {
                applicationServiceCategoria.Add(categoriaDTO);
                return Ok("Categoria cadastrada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // PUT: Atualizar categoria
        [HttpPut]
        public ActionResult Update([FromBody] CategoriaDTO categoriaDTO)
        {
            try
            {
                applicationServiceCategoria.Update(categoriaDTO);
                return Ok("Categoria atualizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // DELETE: Deletar categoria
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                applicationServiceCategoria.Delete(id);
                return Ok("Categoria deletada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
