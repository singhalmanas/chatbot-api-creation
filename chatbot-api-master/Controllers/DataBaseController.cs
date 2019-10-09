using ChatbotApiBusinessLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatbotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataBaseController : ControllerBase
    {
        // GET: api/DataBase
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DataBase/5
        [HttpGet("{id}", Name = "GetDataBase")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DataBase
        [HttpPost]
        public bool Post([FromBody]string database)
        {
            CRUD cRUD = new CRUD();
            return cRUD.CreateDatabase(database);
        }

        [HttpGet]
        public async Task<string[]> GetStoreType()
        {
            MasterBusinessLayer businessLayer = new MasterBusinessLayer();
            return await businessLayer.GetStoreType();
        }
        // PUT: api/DataBase/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
