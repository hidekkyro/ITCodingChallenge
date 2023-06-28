using Microsoft.AspNetCore.Mvc;
using ParedeAPI.Contrato.Servico;
using ParedeAPI.Servico;
using System.Diagnostics;

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
            result.Add("menorParedeGrande", menorCorte);

            if (usarParedeExemplo)
                result.Add("ParedeExemplo", parede);

            return Ok(result);
        }

        /// <summary>
        /// Desenhará uma linha vertical do topo à base que corta o mínimo número de tijolos.
        /// Calculando o tempo de execução
        /// </summary>
        /// <returns>Retornará o mínimo número de tijolos, e o tempo de execução.</returns>
        [HttpGet]
        public IActionResult CortarBenchmark()
        {
            int[][] paredeGrande = _paredeService.GerarParedeMassaGrande();
            int[][] paredeExemplo = _paredeService.GerarParedeExemplo();
            

            if (!_paredeService.IsParede(paredeGrande))
                return BadRequest("Parede fora do padrão, preenche uma parede de uma altura de 1 até 10.000, e uma largura de 1 até 10.000, que contenha no maximo 20.000 tijolos.");


            Stopwatch timer = new Stopwatch();
            timer.Start();
            int menorParedeGrande = _paredeService.ContaParede(paredeGrande);
            TimeSpan tempoParedeGrande = timer.Elapsed;
            timer.Restart();
            int menorCorteExemplo = _paredeService.ContaParede(paredeExemplo);
            TimeSpan tempoParedeExemplo = timer.Elapsed;
            timer.Restart();
            int menorCorteExemplo2 = _paredeService.MenorNumTijolosCortados(paredeGrande);
            TimeSpan tempoParedeExemplo2 = timer.Elapsed;
            timer.Restart();
            int menorCorteExemplo3 = _paredeService.MenorNumTijolosCortados(paredeExemplo);
            TimeSpan tempoParedeExemplo3 = timer.Elapsed;
            timer.Stop();

            int qtd = 0;
            foreach (int[] parede in paredeGrande)
            {
                qtd += parede.Length;
            }

            var paredeGrand = new
            {
                Altura = paredeGrande.GetLength(0),
                QtdTijolo = qtd
            };

            qtd = 0;
            foreach (int[] parede in paredeExemplo)
            {
                qtd += parede.Length;
            }

            var paredeExempl = new
            {
                Altura = paredeExemplo.GetLength(0),
                QtdTijolo = qtd
            };

            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("menorParedeGrande", menorParedeGrande);
            result.Add("tempoParedeGrande", tempoParedeGrande);
            result.Add("paredeGrand", paredeGrand);

            result.Add("menorCorteExemplo", menorCorteExemplo);
            result.Add("tempoParedeExemplo", tempoParedeExemplo);
            result.Add("paredeExempl", paredeExempl);

            result.Add("menorCorteExemplo2", menorCorteExemplo2);
            result.Add("tempoParedeExemplo2", tempoParedeExemplo2);
            result.Add("paredeExempl2", paredeGrand);

            result.Add("menorCorteExemplo3", menorCorteExemplo3);
            result.Add("tempoParedeExemplo3", tempoParedeExemplo3);
            result.Add("paredeExempl3", paredeExempl);

            //if(usarParedeExemplo)
            //    result.Add("ParedeExemplo", parede);

            return Ok(result);
        }
    }
}
