using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.BLL.DTOs
{
    public class SalesReportDTO
    {
        public int LeadId { get; set; }
        public int TotalSalesCount { get; set; }
        public decimal TotalSalesAmount { get; set; }
        public decimal AverageSaleAmount { get; set; }
    }
}
