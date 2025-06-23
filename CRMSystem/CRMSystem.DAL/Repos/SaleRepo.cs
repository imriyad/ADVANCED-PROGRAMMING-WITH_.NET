using CRMSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.DAL.Repos
{
    public class SaleRepo:Repo
    {
        public void Create(Sale s)
        {
            db.Sales.Add(s);
            db.SaveChanges();
        }

        public List<Sale> Get()
        {
            return db.Sales.ToList();
        }

        public Sale Get(int id)
        {
            return db.Sales.Find(id);
        }

        public void Delete(int id)
        {
            var sale = Get(id);
            db.Sales.Remove(sale);
            db.SaveChanges();
        }

        public void Update(Sale s)
        {
            var old = Get(s.Id);
            db.Entry(old).CurrentValues.SetValues(s);
            db.SaveChanges();
        }
    }
}
