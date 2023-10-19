﻿using Microsoft.AspNetCore.Mvc;
using ProjetoEstacionamento.Dto.Vaga;
using ProjetoEstacionamento.Services.Interfaces;
using System.Net;

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
            try
            {
                await vagaService.Cadastrar(vagaRequest);

                return Ok();
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                  new
                  {
                      message = "Algo inesperado ocorreu",
                      detail = exception.Message
                  });
            }
        }

        [HttpGet("consulta-detalhada")]
        public async Task<IActionResult> Consultar([FromServices] IVagaService vagaService)
        {
            try
            {
                return Ok(await vagaService.Consultar());
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                  new
                  {
                      message = "Algo inesperado ocorreu",
                      detail = exception.Message
                  });
            }
        }

        [HttpGet("consultar-vagas-restantes")]
        public async Task<IActionResult> ConsultarVagasRestantes([FromServices] IVagaService vagaService)
        {
            try
            {
                return Ok(await vagaService.ConsultarVagasRestantes());
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                  new
                  {
                      message = "Algo inesperado ocorreu",
                      detail = exception.Message
                  });
            }
        }

        [HttpGet("consultar-total-vagas")]
        public async Task<IActionResult> ConsultarTotalVagas([FromServices] IVagaService vagaService)
        {
            try
            {
                return Ok(await vagaService.ConsultarTotalVagas());
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                  new
                  {
                      message = "Algo inesperado ocorreu",
                      detail = exception.Message
                  });
            }
        }

        [HttpGet("listar-todos-veiculos")]
        public async Task<IActionResult> ListarVeiculos([FromServices] IVagaService vagaService)
        {
            try
            {
                return Ok(await vagaService.ListarVeiculos());
            }
            catch (Exception exception)
            {
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
