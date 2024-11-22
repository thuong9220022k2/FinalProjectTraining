using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class FilterResult
    {
        public string? project_id { get; set; }
        public string? created_date { get; set; }
        public string? actual_start_date { get; set; }
        public string? status { get; set; }
        public string? name { get; set; }
        public string? actual_percent_complete { get; set; }
        public string? limit { get; set; }

        public FilterResult(
            string projectId,
            string createdDate,
            string actualStartDate,
            string status,
            string actualPercentComplete,
            string name, 
            string limit
            )
        {
            this.project_id = projectId;
            this.created_date = createdDate;
            this.actual_start_date = actualStartDate;
            this.status = status;
            this.actual_percent_complete = actualPercentComplete;
            this.name = name;
            this.limit = limit;
        }

    }
}
