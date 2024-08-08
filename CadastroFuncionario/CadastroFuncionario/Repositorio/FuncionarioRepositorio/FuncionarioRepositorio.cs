using CadastroFuncionario.DataContext;
using CadastroFuncionario.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroFuncionario.Repositorio.FuncionarioRepositorio
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly AppDbContext _context;

        public FuncionarioRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> ListarFuncionario()
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                serviceResponse.Dados = await _context.Funcionarios.ToListAsync();
                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum Registro Cadastrado";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = "Nenhum Registro de  Funcionario Localizado";
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<FuncionarioModel>> BuscarFuncionarioPorId(int IdFuncionario)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();
            try
            {
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync( f => f.Id == IdFuncionario);

                if(funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum Funcionario Encontrado";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = funcionario;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = "Nenhum Registro de  Funcionario Localizado";
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;


        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> CriarFuncionario(FuncionarioModel novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
               if(novoFuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = " Informa Os Dados";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = "Nenhum Registro de  Funcionario Localizado";
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeletarFuncionario(int IdFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == IdFuncionario);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum Dados Localizado!";
                    serviceResponse.Sucesso = false;
                }


                _context.Funcionarios.Remove(funcionario);
                serviceResponse.Mensagem = "Funcionario Deletado!";
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;

                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> EditarFuncionario(FuncionarioModel IdFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(f => f.Id == IdFuncionario.Id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum Dados Localizado!";
                    serviceResponse.Sucesso = false;
                }

                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(IdFuncionario);
                await  _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message ;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int IdFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(f => f.Id == IdFuncionario);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario Não Localizado";
                    serviceResponse.Sucesso = false;
                }
                funcionario.Ativo = false;
                funcionario.DataDeAlteracao= DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList(); 

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = "Erro De Registro";
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
