using System;

namespace CRMSystem.BLL.DTOs
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public decimal Amount { get; set; }
        public DateTime SaleDate { get; set; }
        public string Description { get; set; }
    }
}
