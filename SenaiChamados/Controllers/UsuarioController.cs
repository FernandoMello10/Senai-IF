using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SenaiChamados.Domain;
using SenaiChamados.Interfaces.Application;
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

        public UsuarioController(IUsuarioApplication userApplication)
        {
            _application = userApplication;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _application.GetAll();
        }

        [HttpPost]
        public User GetByID(int id)
        {
            return _application.GetByID(id);
        }

        [HttpPost()]
        public IActionResult Login(string email, string password)
        {
            try
            {
                var userExists = _application.Login(email,password);


                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        public IActionResult Save(User newModel)
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

        public IActionResult Update(User updatedModel)
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
