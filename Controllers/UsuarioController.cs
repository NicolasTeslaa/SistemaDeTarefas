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

        [HttpGet("GetAll")]
        public ActionResult<List<UsuarioUpdateModel>> GetAll()
        {
            return Ok();
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<UsuarioUpdateModel>> GetById(string id)
        {
            UsuarioUpdateModel usuario = await _usuarioRepositorio.GetById(id);
            return Ok(usuario);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<UsuarioCreateModel>> Create([FromBody] UsuarioCreateModel usuarioModel)
        {
            await _usuarioRepositorio.Create(usuarioModel);
            return Ok(usuarioModel);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<UsuarioUpdateModel>> Update([FromBody] UsuarioUpdateModel usuarioModel, string id)
        {
            usuarioModel.Id = id;
            usuarioModel = await _usuarioRepositorio.Create(usuarioModel);
            return Ok(usuarioModel);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<UsuarioUpdateModel>> Delete(string id)
        {
            bool apagado = await _usuarioRepositorio.Delete(id);
            return Ok(apagado);
        }
    }
}
