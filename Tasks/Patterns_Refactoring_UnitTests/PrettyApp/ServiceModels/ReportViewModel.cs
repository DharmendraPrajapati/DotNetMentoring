using System;

namespace ServiceModels
{
    public class ReportViewModel
    {
        public int Id { get; set; }

        public CustomerViewModel Customer { get; set; }

        public string ReportData { get; set; }

        public DateTime? UpdatedUtc { get; set; }
    }
}