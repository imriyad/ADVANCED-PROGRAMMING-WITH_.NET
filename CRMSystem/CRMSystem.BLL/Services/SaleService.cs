using CRMSystem.BLL.DTOs;
using CRMSystem.BLL.Interfaces;
using CRMSystem.DAL.interfaces;
using CRMSystem.DAL.Interfaces;
using CRMSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRMSystem.BLL.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repo;
        private readonly ILeadRepository _leadRepo;
        private readonly IEmailService _email;

        public SaleService(ISaleRepository repo, ILeadRepository leadRepo, IEmailService email)
        {
            _repo = repo;
            _leadRepo = leadRepo;
            _email = email;
        }


        public void Create(SaleDTO sale)
        {
            var s = new Sale
            {
                LeadId = sale.LeadId,
                Amount = sale.Amount,
                SaleDate = sale.SaleDate,
                Description = sale.Description
            };

            _repo.Add(s);

            // Send email to lead
            var lead = _leadRepo.GetById(sale.LeadId);
            if (lead != null && !string.IsNullOrEmpty(lead.Email))
            {
                string subject = "New Sale Created";
                string body = $"Dear {lead.FullName},\n\nA new sale of amount ${sale.Amount} has been recorded for you on {sale.SaleDate:yyyy-MM-dd}.\n\nDescription: {sale.Description}\n\nThank you!";
                _email.Send(lead.Email, subject, body);
            }
        }

        public void Delete(int id) => _repo.Delete(id);

        public List<SaleDTO> Get()
        {
            return _repo.GetAll().Select(s => new SaleDTO
            {
                Id = s.Id,
                LeadId = s.LeadId,
                Amount = s.Amount,
                SaleDate = s.SaleDate,
                Description = s.Description
            }).ToList();
        }

        public SaleDTO Get(int id)
        {
            var s = _repo.GetById(id);
            if (s == null) return null;

            return new SaleDTO
            {
                Id = s.Id,
                LeadId = s.LeadId,
                Amount = s.Amount,
                SaleDate = s.SaleDate,
                Description = s.Description
            };
        }

        public void Update(SaleDTO sale)
        {
            var s = new Sale
            {
                Id = sale.Id,
                LeadId = sale.LeadId,
                Amount = sale.Amount,
                SaleDate = sale.SaleDate,
                Description = sale.Description
            };
            _repo.Update(s);
        }
        public List<SaleDTO> GetFiltered(int? leadId, DateTime? fromDate, DateTime? toDate)
        {
            var sales = _repo.GetFiltered(leadId, fromDate, toDate);
            return sales.Select(s => new SaleDTO
            {
                Id = s.Id,
                LeadId = s.LeadId,
                Amount = s.Amount,
                SaleDate = s.SaleDate,
                Description = s.Description
            }).ToList();
        }

        public List<SalesReportDTO> GetSalesReport()
        {
            var sales = _repo.GetAll();

            var report = sales
                .GroupBy(s => s.LeadId)
                .Select(g => new SalesReportDTO
                {
                    LeadId = g.Key,
                    TotalSalesCount = g.Count(),
                    TotalSalesAmount = g.Sum(s => s.Amount),
                    AverageSaleAmount = g.Average(s => s.Amount)
                }).ToList();

            return report;
        }

    }
}
