using System;
using Fspizzaria.Domains;
using Fspizzaria.Interfaces;
using Fspizzaria.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fspizzaria.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PizzariasController : ControllerBase
    {
        private IPizzariaRepository PizzariaRepository { get; set; }

        public PizzariasController()
        {
            PizzariaRepository = new PizzariaRepository();
        }

        [HttpGet("BuscaPorNome/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            try
            {
                Pizzarias pizzaria = PizzariaRepository.BuscarPorNome(nome);
                if (pizzaria == null)
                {
                    return NotFound("Pizzaria não encontrada");
                }
                return Ok(pizzaria);
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex });
            }
        }

        //cadastrar pizza
        [HttpPost]
        [Authorize(Roles= "gandolf@a.a")]
        public IActionResult CadastrarPizza(Pizzarias pizzaria)
        {
            try
            {
                PizzariaRepository.Cadastrar(pizzaria);
                return Ok(new {mensagem = "Pizzaria cadastrada com sucesso"});
            }
            catch (Exception)
            {
                return BadRequest(new { mensagem = "Erro" });
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Listar()
        {
            try
            {
                return Ok(PizzariaRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex });
            }
        }

    }
}