using CRMSystem.DAL.Models;
using CRMSystem.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CRMSystem.DAL.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly CrmDbContext _context;

        public ContactRepository(CrmDbContext context)
        {
            _context = context;
        }

        public List<Contact> GetAll() => _context.Contacts.ToList();

        public Contact GetById(int id) => _context.Contacts.Find(id);

        public void Add(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void Update(Contact contact)
        {
            _context.Entry(contact).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
        }
    }
}
