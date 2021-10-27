using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os Usuarios."
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_usuarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        /// <summary>
        /// Retorna o código da imagem (base64).
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("imagem")]
        public IActionResult getDIR()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                string base64 = _usuarioRepository.ConsultarPerfilDir(idUsuario);

                return Ok(base64);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Cadastra um novoUsuario.
        /// </summary>
        /// <param name="novoUsuario"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201);

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        /// <summary>
        /// Subir a imagem.
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost("imagem")]
        public IActionResult postDir(IFormFile arquivo)
        {
            try
            {
                if (arquivo.Length < 5000) //5MB
                    return BadRequest(new { mensagem = "O tamanho máximo da imagem foi atingido." });

                string extensao = arquivo.FileName.Split('.').Last();


                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                _usuarioRepository.SalvarPerfilDir(arquivo, idUsuario);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Deleta o Usuario através do Id.
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpDelete("{IdUsuario}")]
        public IActionResult Deletar(int IdUsuario)
        {
            try
            {
                _usuarioRepository.Deletar(IdUsuario);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
