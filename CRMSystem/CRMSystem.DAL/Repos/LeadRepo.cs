using CRMSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.DAL.Repos
{
    public class LeadRepo : Repo
    {
        public void Create(Lead l)
        {
            db.Leads.Add(l);
            db.SaveChanges();
        }

        public List<Lead> Get()
        {
            return db.Leads.ToList();
        }

        public Lead Get(int id)
        {
            return db.Leads.Find(id);
        }

        public void Delete(int id)
        {
            var lead = Get(id);
            db.Leads.Remove(lead);
            db.SaveChanges();
        }

        public void Update(Lead l)
        {
            var old = Get(l.Id);
            db.Entry(old).CurrentValues.SetValues(l);
            db.SaveChanges();
        }
    }
}

