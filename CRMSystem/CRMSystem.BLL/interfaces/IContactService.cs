using CRMSystem.BLL.DTOs;
using System.Collections.Generic;

namespace CRMSystem.BLL.Interfaces
{
    public interface IContactService
    {
        List<ContactDTO> Get();
        ContactDTO Get(int id);
        void Create(ContactDTO contact);
        void Update(ContactDTO contact);
        void Delete(int id);
    }
}
