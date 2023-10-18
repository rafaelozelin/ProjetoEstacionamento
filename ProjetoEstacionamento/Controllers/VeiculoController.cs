using Microsoft.AspNetCore.Mvc;
using ProjetoEstacionamento.Dto.Veiculo;
using ProjetoEstacionamento.Enums;
using ProjetoEstacionamento.Factories;
using ProjetoEstacionamento.Services;

namespace ProjetoEstacionamento.Controllers
{
    [ApiController]
    [Route("api/v1/veiculo")]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoServiceFactory _veiculoServiceFactory;

        public VeiculoController(IVeiculoServiceFactory veiculoServiceFactory)
        {
            _veiculoServiceFactory = veiculoServiceFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] VeiculoRequest veiculoRequest)
        {
            var servico = _veiculoServiceFactory.Create(veiculoRequest.TipoVeiculo);

            await servico.CadastrarAsync(veiculoRequest);

            return NoContent();
        }
    }
}
