using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatbotApiBusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("RunTest")]
        public async Task<ActionResult<bool>> Val()
        {
            AzureTableBusinessLayer bl = new AzureTableBusinessLayer();
            await bl.RunSamples();
            return true;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            AzureTableBusinessLayer bl = new AzureTableBusinessLayer();
            await bl.RunSamples();
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
