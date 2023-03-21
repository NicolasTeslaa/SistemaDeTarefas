using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface UsuarioRepositorio
    {
        Task<List<UsuarioModel>> GetAll();
        Task<UsuarioModel> GetById(int id);
        Task<UsuarioModel> Create(UsuarioModel usuario);
        Task<UsuarioModel> Update(UsuarioModel usuario, int id);
        Task<bool> Delete(int id);
    }
}
