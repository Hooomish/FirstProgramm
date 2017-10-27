using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Xrm.Sdk;
using FirstProgramm.Models;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Sdk.Query;

namespace FirstProgramm.Controllers
{
    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {
        CrmServiceClient service = new CrmServiceClient(
                "AuthType=AD;" +
                "Url=https://studdev.scnsoft.com/studdev; " +
                "Domain=MAIN; " +
                "Username=crm-test17@scnsoft.com; " +
                "Password=Abcd1234");
        string entityName = "scnsoft_securitypaper";

        [Route("read")]
        [HttpGet]
        public IEnumerable<Entity> Read()
        {
            var query = new QueryExpression(entityName) { ColumnSet = new ColumnSet(true) };

            return service.RetrieveMultiple(query).Entities;
        }

        [Route("read/{id}")]
        [HttpGet]
        public Entity Read(string id)
        {
            var SecurityPaper = service.Retrieve(entityName, Guid.Parse(id), new ColumnSet(true));

            if (SecurityPaper != null)
                return SecurityPaper;
            else
                return null;
        }
        
        [Route("create")]
        [HttpPost]
        public void Create([FromBody]MyEntity ME)
        {
            var SecurityPaper = new Entity(entityName);
            SecurityPaper.Id = Guid.NewGuid();
            SecurityPaper["scnsoft_name"] = ME.Name;
            SecurityPaper["scnsoft_description"] = ME.Description;
            SecurityPaper["scnsoft_product_name"] = ME.ProductName;

            service.Create(SecurityPaper);
        }

        [Route("update/{id}")]
        [HttpPut]
        public void Update(string id, MyEntity ME)
        {
            var SecurityPaper = service.Retrieve(entityName, Guid.Parse(id), new ColumnSet(true));

            if (SecurityPaper != null)
            {
                SecurityPaper["scnsoft_name"] = ME.Name;
                SecurityPaper["scnsoft_description"] = ME.Description;
                SecurityPaper["scnsoft_product_name"] = ME.ProductName;
            }

            service.Update(SecurityPaper);
        }

        [Route("delete/{id}")]
        public void Delete(string id)
        {
            var SecurityPaper = service.Retrieve(entityName, Guid.Parse(id), new ColumnSet(true));

            if(SecurityPaper != null)
                service.Delete(entityName, Guid.Parse(id));
        }
    }
}






