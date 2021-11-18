using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SenaiChamados.Interfaces.Application;
using SenaiChamados.Models;
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
        /// <param name="loginModel">Input para o login contendo email e senha do usuário</param>
        /// <returns>Token de autorização JWT - StatusCode 200</returns>
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

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_application.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult GetByID(int id)
        {
            try
            {
                return Ok(_application.GetByID(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        public IActionResult Save(Usuario newModel)
        {
            try
            {
                _application.Save(newModel);
                return StatusCode(204);
            }
            catch
            {
                return BadRequest();
            }
        }

        public IActionResult Update(Usuario updatedModel)
        {
            try
            {
                _application.Update(updatedModel);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
