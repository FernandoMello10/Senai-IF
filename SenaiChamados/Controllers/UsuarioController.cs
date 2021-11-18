using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SenaiChamados.Interfaces.Application;
using SenaiChamados.Models;
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
