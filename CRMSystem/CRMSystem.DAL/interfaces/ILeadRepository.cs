using CRMSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.DAL.interfaces
{
    public interface ILeadRepository
    {
        List<Lead> GetAll();
        Lead GetById(int id);
        void Add(Lead lead);
        void Update(Lead lead);
        void Delete(int id);
    }
}
