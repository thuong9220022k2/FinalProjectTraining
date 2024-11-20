using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    internal class ServiceResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}
