using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaDeTarefasDBContext _dbContext;
        public UsuarioRepositorio(SistemaDeTarefasDBContext sistemaDeTarefasDBContext)
        {
            _dbContext = sistemaDeTarefasDBContext;
        }

        public async Task<UsuarioModel> GetById(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> GetAll() 
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Create(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> Update(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await GetById(id);

            if(usuarioPorId == null)
            {
                throw new Exception("Usuario não encontrado");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync(); 

            return usuarioPorId;
        }

        public async Task<bool> Delete(int id)
        {
            UsuarioModel usuarioPorId = await GetById(id);

            if (usuarioPorId == null)
            {
                throw new Exception("Usuario não encontrado");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

    public interface IUsuarioRepositorio
    {
    }
}
