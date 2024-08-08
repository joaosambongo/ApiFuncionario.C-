using CadastroFuncionario.Models;

namespace CadastroFuncionario.Repositorio.FuncionarioRepositorio
{
    public interface IFuncionarioRepositorio
    {
        Task<ServiceResponse<List<FuncionarioModel>>> ListarFuncionario();
        Task<ServiceResponse<List<FuncionarioModel>>> CriarFuncionario(FuncionarioModel novoFuncionario);
        Task<ServiceResponse<FuncionarioModel>> BuscarFuncionarioPorId(int IdFuncionario);
        Task<ServiceResponse<List<FuncionarioModel>>> EditarFuncionario(FuncionarioModel IdFuncionario);
        Task<ServiceResponse<List<FuncionarioModel>>> DeletarFuncionario(int IdFuncionario);
        Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int IdFuncionario);




    }
}
