using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioUpdateModel>> GetAll();
        Task<UsuarioUpdateModel> GetById(string id);
        Task<UsuarioCreateModel> Create(UsuarioCreateModel usuario);
        Task<UsuarioUpdateModel> Update(UsuarioUpdateModel usuario, string id);
        Task<bool> Delete(string id);
    }
}