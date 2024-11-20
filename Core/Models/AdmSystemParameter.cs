using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    internal class AdmSystemParameter : BaseModel
    {
        public int system_parameter_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public int status { get; set; }
        public int feature_id { get; set; }
        public int deleted { get; set; }
        public int version { get; set; }
    }
}
