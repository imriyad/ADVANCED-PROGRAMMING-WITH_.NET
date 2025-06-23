using System;

namespace CRMSystem.DAL.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int LeadId { get; set; }  // Foreign key to Lead
        public decimal Amount { get; set; }
        public DateTime SaleDate { get; set; }
        public string Description { get; set; }
    }
}
