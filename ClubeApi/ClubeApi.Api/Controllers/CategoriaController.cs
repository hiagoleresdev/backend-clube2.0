using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.ApplicationServices;
using ClubeApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
                var result = new
                {
                    message = $"Erro: {ex.Message}",
                };
                return BadRequest(JsonConvert.SerializeObject(result));
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
                {
                    var result = new
                    {
                        message = "A categoria buscada não foi encontrada",
                    };
                    return NotFound(JsonConvert.SerializeObject(result));
                }
                else
                    return Ok(categoria);
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

        // POST: Cadastrar categoria
        [HttpPost]
        public ActionResult Add([FromBody] CategoriaDTO categoriaDTO)
        {
            try
            {
                int resultado = applicationServiceCategoria.Add(categoriaDTO);
                
                if(resultado == 1)
                {
                    var result = new
                    {
                        message = "Categoria cadastrada com sucesso",
                    };
                    return Ok(JsonConvert.SerializeObject(result));
                }
                else
                {
                    var result = new
                    {
                        message = "A categoria informada já consta na base de dados",
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

        // PUT: Atualizar categoria
        [HttpPut]
        public ActionResult Update([FromBody] CategoriaDTO categoriaDTO)
        {
            try
            {
                applicationServiceCategoria.Update(categoriaDTO);
                var result = new
                {
                    message = "Categoria atualizada com sucesso",
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

        // DELETE: Deletar categoria
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                int resultado = applicationServiceCategoria.Delete(id);
                if(resultado == 1)
                {
                    var result = new
                    {
                        message = "Categoria deletada com sucesso",
                    };
                    return Ok(JsonConvert.SerializeObject(result));
                }
                else if(resultado == 0)
                {
                    var result = new
                    {
                        message = "A categoria não pode ser excluída por estar em utilização",
                    };
                    return Conflict(JsonConvert.SerializeObject(result));
                }
                else
                {
                    var result = new
                    {
                        message = "Ocorreu um erro na exclusão do item",
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
