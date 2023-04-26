using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Entities.Models;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly SistemaDeTarefasDBContext _context;
        public UsuarioController(SistemaDeTarefasDBContext context)
        {
            _context = context;
        }

        private readonly SistemaDeTarefasDBContext context;

        [HttpGet("GetAll")]
        public IEnumerable<Usuario> Get()
        {
            return _context.Usuarios.ToList();
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<Usuario> GetById(string id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(c => c.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UsuarioCreateModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var novoUsuario = new Usuario
            {
                Id = Guid.NewGuid().ToString(),
                Email = usuarioModel.Email,
                Nome = usuarioModel.Nome
            };

            _context.Usuarios.Add(novoUsuario);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UsuarioUpdateModel usuario)
        {
            var usuarioExistente = await _context.Usuarios.FindAsync(id);

            if (usuarioExistente == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            usuarioExistente.Email = usuario.Email;
            usuarioExistente.Nome = usuario.Nome;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
