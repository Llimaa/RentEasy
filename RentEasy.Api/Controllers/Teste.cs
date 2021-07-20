using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentEasy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Teste : ControllerBase
    {
        private readonly ILogger<Teste> _logger;

        public Teste(ILogger<Teste> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public IActionResult SayHello(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new NullReferenceException();
                //_logger.LogError (new Exception("ss"), "Mensagem de erro");
                return StatusCode(500, value: "");
            }
            return Ok($"Hello {name}");
        }
    }
}
