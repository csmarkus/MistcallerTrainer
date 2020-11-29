using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MistcallerTrainer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistcallerTrainer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RuneController : ControllerBase
    {
        private readonly ILogger<RuneController> _logger;

        public RuneController(ILogger<RuneController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public object Get()
        {
            RuneSet rs = new RuneSet();

            return new { values = rs.Runes.Select(x => new { text = x.ToString(), value = x.GetCode() }) };
        }
    }
}
