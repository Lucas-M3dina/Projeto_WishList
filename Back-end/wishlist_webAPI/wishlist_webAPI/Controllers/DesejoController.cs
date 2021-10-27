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

        /// <summary>
        /// Lista todos os Desejos.
        /// </summary>
        /// <returns></returns>
        //[Authorize]
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
        /// <summary>
        /// Cadastrar um novo Desejo.
        /// </summary>
        /// <param name="novoDesejo"></param>
        /// <returns></returns>
        //[Authorize]
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
        /// <summary>
        /// Deleta o Desejo através do Id.
        /// </summary>
        /// <param name="IdDesejo"></param>
        /// <returns></returns>
        //[Authorize]
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
