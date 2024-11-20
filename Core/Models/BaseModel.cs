using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    internal class BaseModel
    {
        public string created_by { get; set; }
        public DateTime created_dtg { get; set; }
        public string updated_by { get; set; }
        public DateTime updated_dtg { get; set; }
    }
}
