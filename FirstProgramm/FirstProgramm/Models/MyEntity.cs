using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace FirstProgramm.Models
{
    public class MyEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ProductName { get; set; }

    }
}