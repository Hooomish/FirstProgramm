using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstProgramm.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> Read()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public string Read(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Create([FromBody]string value)
        {
        }

        [HttpPut]
        public void Update(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
