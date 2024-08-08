using CadastroFuncionario.Models;
using CadastroFuncionario.Repositorio.FuncionarioRepositorio;
using Microsoft.AspNetCore.Mvc;

namespace CadastroFuncionario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {

        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        public FuncionarioController(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }


        [HttpGet("ListarFuncionario")]
        public async Task<ActionResult <ServiceResponse<List<FuncionarioModel>>>> ListarFuncionario()
        {
            return Ok( await _funcionarioRepositorio.ListarFuncionario());
        }

        [HttpPost("CriarFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CriarFuncionario(FuncionarioModel novoFuncionario)
        {
            return Ok(await _funcionarioRepositorio.CriarFuncionario(novoFuncionario));
        }



        [HttpGet("BuscarFuncionarioPorId/{IdFuncionario}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> BuscarFuncionarioPorId(int IdFuncionario)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = await _funcionarioRepositorio.BuscarFuncionarioPorId(IdFuncionario);
            return Ok(serviceResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> EditarFuncionario(FuncionarioModel IdFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioRepositorio.EditarFuncionario(IdFuncionario);

            return Ok(serviceResponse);

        }


        [HttpPut("InativaFuncionario/{IdFuncionario}")]
         public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> InativaFuncionario(int IdFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioRepositorio.InativaFuncionario(IdFuncionario);
            return Ok(serviceResponse); 
        }

        [HttpDelete("DeletarFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeletarFuncionario(int IdFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioRepositorio.DeletarFuncionario(IdFuncionario);
            return Ok(serviceResponse);
        }

    }   
}
