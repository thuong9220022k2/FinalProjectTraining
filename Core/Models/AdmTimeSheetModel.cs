using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class AdmTimeSheetModel : BaseModel
    {
        public int time_sheet_id { get; set; }
        public int project_id { get; set; }
        public string module { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public double total_duration { get; set; }
        public DateTime actual_start_date { get; set; }
        public int actual_percent_complete { get; set; }
        public string issue { get; set; }
        public int current_state { get; set; }
        public int deleted { get; set; }
        public int version { get; set; }

    }
}
