using Microsoft.AspNetCore.Mvc;

namespace TaxaDeJuros.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaDeJurosController : ControllerBase
    {
        [HttpGet]
        [Route("taxaJuros")]
        public IActionResult ObterTaxaDeJuros()
        {
            const double taxaDeJuros = 0.01;
            return Ok(taxaDeJuros);
        }
    }
}