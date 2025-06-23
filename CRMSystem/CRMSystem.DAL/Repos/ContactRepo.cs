using CRMSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.DAL.Repos
{
    public class ContactRepo : Repo
    {
            public void Create(Contact c)
            {
                db.Contacts.Add(c);
                db.SaveChanges();
            }

            public List<Contact> Get()
            {
                return db.Contacts.ToList();
            }

            public Contact Get(int id)
            {
                return db.Contacts.Find(id);
            }

            public void Delete(int id)
            {
                var contact = Get(id);
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }

            public void Update(Contact c)
            {
                var old = Get(c.Id);
                db.Entry(old).CurrentValues.SetValues(c);
                db.SaveChanges();
            }
        
    }
}
