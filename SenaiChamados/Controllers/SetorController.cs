using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiChamados.Interfaces.Application;
using System;

namespace SenaiChamados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        private ISetorApplication _application { get; set; }
        public SetorController(ISetorApplication setorApplication)
        {
            _application = setorApplication;
        }

        //GET api/Setor/
        /// <summary>
        /// Busca todos os setores
        /// </summary>
        /// <returns>Todos os setores - Status Code 200</returns>
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
    }
}
