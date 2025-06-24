using CRMSystem.DAL.Models;
using System;
using System.Collections.Generic;

namespace CRMSystem.DAL.Interfaces
{
    public interface ISaleRepository
    {
        List<Sale> GetAll();
        Sale GetById(int id);
        void Add(Sale sale);
        void Update(Sale sale);
        void Delete(int id);

        List<Sale> GetFiltered(int? leadId, DateTime? fromDate, DateTime? toDate);

    }
}
