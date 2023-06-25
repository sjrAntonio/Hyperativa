using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hyperativa_Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hyperativa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public IActionResult CadastraCliente([FromBody]Hyperativa_BancoDados.Cliente clienteDetalhes)
        {
            bool resultado = cadastrarCliente.cadastrarClienteCC(clienteDetalhes);

            if (resultado)
            {
                return Ok(new { result = "Sucesso" });
            }
            else
            {
                return ValidationProblem( new ValidationProblemDetails {Detail = "Erro ao cadastrar cliente" } );
            }
        }
    }
}
