using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wishlist_webAPI.Domains;
using wishlist_webAPI.Interfaces;
using wishlist_webAPI.Repositores;

namespace wishlist_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DesejoController : ControllerBase
    {
        private IDesejoRepository _desejoRepository { get; set; }

        public DesejoController()
        {
            _desejoRepository = new DesejoRepository();
        }


        [Authorize]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_desejoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Desejo novoDesejo)
        {
            try
            {
                _desejoRepository.Cadastrar(novoDesejo);

                return StatusCode(201);

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpDelete("{IdDesejo}")]
        public IActionResult Deletar(int IdDesejo)
        {
            try
            {
                _desejoRepository.Deletar(IdDesejo);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
