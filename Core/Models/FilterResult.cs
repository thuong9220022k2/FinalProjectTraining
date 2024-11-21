using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class FilterResult
    {
        public string? projectId { get; set; }
        public string? createdDate { get; set; }
        public string? actualStartDate { get; set; }
        public string? status { get; set; }
        public string? name { get; set; }
        public string? actualPercentComplete { get; set; }
        public string? offset { get; set; }
        public string? limit { get; set; }

        public FilterResult(string projectId, string createdDate, string actualStartDate, string status, string actualPercentComplete, string name, string offset, string limit)
        {
            this.projectId = projectId;
            this.createdDate = createdDate;
            this.actualStartDate = actualStartDate;
            this.status = status;
            this.actualPercentComplete = actualPercentComplete;
            this.name = name;
            this.offset = offset;
            this.limit = limit;
        }

    }
}
