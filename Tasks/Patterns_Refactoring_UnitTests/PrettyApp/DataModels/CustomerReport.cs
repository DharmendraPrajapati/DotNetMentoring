using System;
using ServiceModels;

namespace DataModels
{
    public class Report
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public string ReportData { get; set; }

        public DateTime? CreatedUtc { get; set; }

        public DateTime? UpdatedUtc { get; set; }
    }
}