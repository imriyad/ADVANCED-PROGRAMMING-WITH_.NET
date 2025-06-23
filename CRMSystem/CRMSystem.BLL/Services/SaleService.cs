using CRMSystem.BLL.DTOs;
using CRMSystem.BLL.Interfaces;
using CRMSystem.DAL.Interfaces;
using CRMSystem.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRMSystem.BLL.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repo;

        public SaleService(ISaleRepository repo)
        {
            _repo = repo;
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
    }
}
