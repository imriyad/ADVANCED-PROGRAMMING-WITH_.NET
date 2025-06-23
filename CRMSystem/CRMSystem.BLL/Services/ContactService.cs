using CRMSystem.BLL.DTOs;
using CRMSystem.BLL.Interfaces;
using CRMSystem.DAL.Interfaces;
using CRMSystem.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRMSystem.BLL.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;

        public ContactService(IContactRepository repo)
        {
            _repo = repo;
        }

        public void Create(ContactDTO contact)
        {
            var c = new Contact
            {
                FullName = contact.FullName,
                Email = contact.Email,
                Phone = contact.Phone,
                Company = contact.Company,
                CreatedAt = contact.CreatedAt
            };
            _repo.Add(c);
        }

        public void Delete(int id) => _repo.Delete(id);

        public List<ContactDTO> Get()
        {
            return _repo.GetAll().Select(c => new ContactDTO
            {
                Id = c.Id,
                FullName = c.FullName,
                Email = c.Email,
                Phone = c.Phone,
                Company = c.Company,
                CreatedAt = c.CreatedAt
            }).ToList();
        }

        public ContactDTO Get(int id)
        {
            var c = _repo.GetById(id);
            if (c == null) return null;

            return new ContactDTO
            {
                Id = c.Id,
                FullName = c.FullName,
                Email = c.Email,
                Phone = c.Phone,
                Company = c.Company,
                CreatedAt = c.CreatedAt
            };
        }

        public void Update(ContactDTO contact)
        {
            var c = new Contact
            {
                Id = contact.Id,
                FullName = contact.FullName,
                Email = contact.Email,
                Phone = contact.Phone,
                Company = contact.Company,
                CreatedAt = contact.CreatedAt
            };
            _repo.Update(c);
        }
    }
}
