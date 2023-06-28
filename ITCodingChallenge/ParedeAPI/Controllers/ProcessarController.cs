using Microsoft.AspNetCore.Mvc;
using ParedeAPI.Contrato.Servico;
using ParedeAPI.Servico;

namespace ParedeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessarController : ControllerBase
    {
        private readonly IParedeService _paredeService;


        public ProcessarController(IParedeService paredeService)
        {
            _paredeService = paredeService;
        }

        /// <summary>
        /// desenhará uma linha vertical do topo à base que corta o mínimo número de tijolos.
        /// </summary>
        /// <param name="parede">Array de Array de Int, linha e seus tijolos de tamanhos diferentes.</param>
        /// <param name="usarParedeExemplo">Usar a parede do enunciado.</param>
        /// <returns>retornará o mínimo número de tijolos, e se usado a parede exemplo, retornará a também.</returns>
        [HttpPost]
        public IActionResult Cortar(int[][]? parede, bool usarParedeExemplo = false)
        {
            if (usarParedeExemplo)
                parede = _paredeService.GerarParedeExemplo();
            else
                if (!_paredeService.IsParede(parede))
                    return BadRequest("Parede fora do padrão, preenche uma parede de uma altura de 1 até 10.000, e uma largura de 1 até 10.000, que contenha no maximo 20.000 tijolos.");

            int menorCorte = _paredeService.ContaParede(parede);

            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("MenorCorte", menorCorte);

            if(usarParedeExemplo)
                result.Add("ParedeExemplo", parede);

            return Ok(result);
        }
    }
}
