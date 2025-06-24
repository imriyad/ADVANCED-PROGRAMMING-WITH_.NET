using CRMSystem.DAL.Models;
using CRMSystem.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CRMSystem.DAL.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly CrmDbContext _context;

        public SaleRepository(CrmDbContext context)
        {
            _context = context;
        }

        public List<Sale> GetAll() => _context.Sales.ToList();

        public List<Sale> GetFiltered(int? leadId, DateTime? fromDate, DateTime? toDate)
        {
            var query = _context.Sales.AsQueryable();

            if (leadId.HasValue)
                query = query.Where(s => s.LeadId == leadId.Value);

            if (fromDate.HasValue)
                query = query.Where(s => s.SaleDate >= fromDate.Value);

            if (toDate.HasValue)
                query = query.Where(s => s.SaleDate <= toDate.Value);

            return query.ToList();
        }

        public Sale GetById(int id) => _context.Sales.Find(id);

        public void Add(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }

        public void Update(Sale sale)
        {
            _context.Entry(sale).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var sale = _context.Sales.Find(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                _context.SaveChanges();
            }
        }
        
    }
}
