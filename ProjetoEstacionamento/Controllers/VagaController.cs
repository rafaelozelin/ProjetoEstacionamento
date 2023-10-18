using Azure;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ProjetoEstacionamento.Dto.Vaga;
using ProjetoEstacionamento.Services;

namespace ProjetoEstacionamento.Controllers
{
    [ApiController]
    [Route("api/v1/vaga")]
    public class VagaController : ControllerBase
    {
        public VagaController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromServices] IVagaService vagaService, [FromBody] List<VagaRequest> vagaRequest)
        {
           await vagaService.Cadastrar(vagaRequest);

            return NoContent();
        }

        [HttpGet("consulta-detalhada")]
        public async Task<IActionResult> Consultar([FromServices] IVagaService vagaService)
        {
            return Ok(await vagaService.Consultar());
        }

        [HttpGet("consultar-vagas-restantes")]
        public async Task<IActionResult> ConsultarVagasRestantes([FromServices] IVagaService vagaService)
        {
            return Ok(await vagaService.ConsultarVagasRestantes());
        }

        [HttpGet("consultar-vagas-restante")]
        public async Task<IActionResult> ConsultarTotalVagas([FromServices] IVagaService vagaService)
        {
            return Ok(await vagaService.ConsultarTotalVagas());
        }
    }
}
