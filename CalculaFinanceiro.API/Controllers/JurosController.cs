using CalculoFinanceiro.Aplicacao;
using Microsoft.AspNetCore.Mvc;

namespace CalculaFinanceiro.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JurosController : ControllerBase
    {
        private readonly ICalculoDeJurosCompostos _calculoDeJurosCompostos;
        private readonly IConsultaDeRepositorios _consultaDeRepositorios;

        public JurosController(IConsultaDeRepositorios consultaDeRepositorios,
            ICalculoDeJurosCompostos calculoDeJurosCompostos)
        {
            _consultaDeRepositorios = consultaDeRepositorios;
            _calculoDeJurosCompostos = calculoDeJurosCompostos;
        }

        [HttpGet]
        [Route("calculajuros")]
        public IActionResult ObterValorDoJuros(decimal valorInicial, int meses)
        {
            var valorDoJuros = _calculoDeJurosCompostos.Calcular(valorInicial, meses);
            return Ok(valorDoJuros);
        }

        [HttpGet]
        [Route("showmethecode")]
        public string ObterEnderecoDoRepositorio()
        {
            var linkDoRepositorio = _consultaDeRepositorios.ObterLinkDoRepositorio();
            return linkDoRepositorio;
        }
    }
}