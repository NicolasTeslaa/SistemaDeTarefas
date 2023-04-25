using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        [HttpGet]
        public ActionResult<List<UsuarioModel>> GetAll()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> GetById(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.GetById(id);
            return Ok(usuario);
        }
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Create([FromBody] UsuarioModel usuarioModel)
        {
            await _usuarioRepositorio.Create(usuarioModel);
            return Ok(usuarioModel);
        }

    }
}
