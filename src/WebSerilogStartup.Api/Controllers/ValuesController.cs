using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace WebSerilogStartup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static int _getCallCount;

        private readonly ILogger<ValuesController> _logger;
        private readonly IDiagnosticContext _diagnosticContext;

        public ValuesController(ILogger<ValuesController> logger, IDiagnosticContext diagnosticContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _diagnosticContext = diagnosticContext ?? throw new ArgumentNullException(nameof(diagnosticContext));

        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogInformation("Calling Values.Get");
            
            _diagnosticContext.Set("GetCallCount", Interlocked.Increment(ref _getCallCount), true);
            return new string[] { "value1", "value2" };

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException($"value: {value}");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
