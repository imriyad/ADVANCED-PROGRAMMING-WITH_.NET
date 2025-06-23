using CRMSystem.DAL.Models;
using System.Collections.Generic;

namespace CRMSystem.DAL.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(int id);
    }
}
