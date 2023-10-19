using Microsoft.AspNetCore.Mvc;
using ProjetoEstacionamento.Dto.Veiculo;
using ProjetoEstacionamento.Enums;
using ProjetoEstacionamento.Factories;
using System.Net;

namespace ProjetoEstacionamento.Controllers
{
    [ApiController]
    [Route("api/v1/veiculo")]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoServiceFactory _veiculoServiceFactory;
        protected readonly ILogger<VeiculoController> _logger;

        public VeiculoController(IVeiculoServiceFactory veiculoServiceFactory, ILogger<VeiculoController> logger)
        {
            _veiculoServiceFactory = veiculoServiceFactory;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] VeiculoRequest veiculoRequest)
        {
            try
            {
                var servico = _veiculoServiceFactory.Create(veiculoRequest.TipoVeiculo);

                await servico.CadastrarAsync(veiculoRequest);

                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogWarning($"Algo inesperado ocorreu no cadastro do veículo: {exception.Message}");

                return StatusCode((int)HttpStatusCode.InternalServerError,
                  new
                  {
                      message = "Algo inesperado ocorreu",
                      detail = exception.Message
                  });
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromBody] VeiculoRequest veiculoRequest, int id)
        {
            try
            {
                var servico = _veiculoServiceFactory.Create(veiculoRequest.TipoVeiculo);

                await servico.AtualizarAsync(veiculoRequest, id);

                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogWarning($"Algo inesperado ocorreu na atualização do veículo: {exception.Message}");

                return StatusCode((int)HttpStatusCode.InternalServerError,
                  new
                  {
                      message = "Algo inesperado ocorreu",
                      detail = exception.Message
                  });
            }
        }

        [HttpGet("listar/{tipoVeiculo}")]
        public async Task<IActionResult> ListarVeiculos(TipoVeiculo tipoVeiculo)
        {
            try
            {
                var servico = _veiculoServiceFactory.Create(tipoVeiculo);

                return Ok(await servico.ListarAsync());
            }
            catch (Exception exception)
            {
                _logger.LogWarning($"Algo inesperado ocorreu na listagem de veiculos: {exception.Message}");

                return StatusCode((int)HttpStatusCode.InternalServerError,
                  new
                  {
                      message = "Algo inesperado ocorreu",
                      detail = exception.Message
                  });
            }
        }
    }
}
