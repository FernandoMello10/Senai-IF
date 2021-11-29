using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SenaiChamados.Interfaces.Application;
using SenaiChamados.Domain;
using SenaiChamados.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenaiChamados.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApplication _application;

        public UsuarioController(IUsuarioApplication UsuarioApplication)
        {
            _application = UsuarioApplication;
        }

        //POST api/usuario/login
        /// <summary>
        /// Autentica um usuário através de email e senha.
        /// </summary>
        /// <param name="loginModel">Modelo de input para o login</param>
        /// <returns>Token de autorização JWT - StatusCode 200 ou StatusCode 400</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost("login")]
        public IActionResult Login(LoginViewModel loginModel)
        {
            try
            {
                var tokenModel = _application.Login(loginModel);

                if (tokenModel is null)
                    return StatusCode(401, "Email e/ou senha incorretos");

                return Ok(tokenModel);
            }
            catch
            {
                return BadRequest();
            }
        }

        //POST api/Usuario
        /// <summary>
        /// Cadastra um usuário.
        /// </summary>
        /// <param name="cadastroModel">Modelo de input para o cadastro</param>
        /// <returns>StatusCode 200 ou StatusCode 400</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Cadastrar(CadastroViewModel cadastroModel)
        {
            try
            {
                _application.Cadastrar(cadastroModel);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                return Ok(_application.BuscarTodos());
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult BuscarPorID(int id)
        {
            try
            {
                return Ok(_application.BuscarPorID(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// NÃO USE
        /// </summary>
        /// <param name="modeloNovo"></param>
        /// <returns></returns>
        public IActionResult Salvar(UsuarioDTO modeloNovo)
        {
            try
            {
                _application.Salvar(modeloNovo);
                return StatusCode(204);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult Atualizar(UsuarioDTO modeloAtualizado)
        {
            try
            {
                _application.Atualizar(modeloAtualizado);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
