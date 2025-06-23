using CRMSystem.BLL.DTOs;
using CRMSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.BLL.interfaces
{
        public interface ILeadService
        {
            void Create(LeadDTO l);
            List<LeadDTO> Get();
            LeadDTO Get(int id);
            void Update(LeadDTO l);
            void Delete(int id);
        }
}
