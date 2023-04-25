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
        [HttpGet("/Usuario/GetAll")]
        public ActionResult<List<UsuarioModel>> GetAll()
        {
            return Ok();
        }
        [HttpGet("/Usuario/GetById/{id}")]
        public async Task<ActionResult<UsuarioModel>> GetById(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.GetById(id);
            return Ok(usuario);
        }
        [HttpPost("/Usuario/Create")]
        public async Task<ActionResult<UsuarioModel>> Create([FromBody] UsuarioModel usuarioModel)
        {
            await _usuarioRepositorio.Create(usuarioModel);
            return Ok(usuarioModel);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<UsuarioModel>> Update([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRepositorio.Create(usuarioModel);
            return Ok(usuario);
        }
        [HttpDelete("Delete/{id}")]
          public async Task<ActionResult<UsuarioModel>> Delete(int id)
        {
            bool apagado = await _usuarioRepositorio.Delete(id);
            return Ok(apagado);
        }

    }
}
