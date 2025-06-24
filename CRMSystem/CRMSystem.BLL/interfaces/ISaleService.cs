using CRMSystem.BLL.DTOs;
using System;
using System.Collections.Generic;

namespace CRMSystem.BLL.Interfaces
{
    public interface ISaleService
    {
        List<SaleDTO> Get();
        SaleDTO Get(int id);
        void Create(SaleDTO sale);
        void Update(SaleDTO sale);
        void Delete(int id);

        List<SaleDTO> GetFiltered(int? leadId, DateTime? fromDate, DateTime? toDate);

        List<SalesReportDTO> GetSalesReport();

    }
}
