using CRMSystem.DAL.interfaces;
using CRMSystem.DAL.Models;
using System.Collections.Generic;
using System.Data.Entity; 
using System.Linq;

namespace CRMSystem.DAL.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly CrmDbContext _context;

        public LeadRepository(CrmDbContext context)
        {
            _context = context;
        }

        // Get all leads
        public List<Lead> GetAll()
        {
            return _context.Leads.ToList();
        }

        // Get lead by ID
        public Lead GetById(int id)
        {
            return _context.Leads.Find(id);
        }

        // Add a new lead
        public void Add(Lead lead)
        {
            _context.Leads.Add(lead);
            _context.SaveChanges();
        }

        // Update an existing lead
        public void Update(Lead lead)
        {
            _context.Entry(lead).State = EntityState.Modified; 
            _context.SaveChanges();
        }

        // Delete a lead by ID
        public void Delete(int id)
        {
            var lead = _context.Leads.Find(id);
            if (lead != null)
            {
                _context.Leads.Remove(lead);
                _context.SaveChanges();
            }
        }
    }
}
