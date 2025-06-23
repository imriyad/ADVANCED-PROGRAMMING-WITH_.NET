using CRMSystem.BLL.interfaces;
using CRMSystem.BLL.Interfaces;
using CRMSystem.BLL.Services;
using CRMSystem.DAL;
using CRMSystem.DAL.interfaces;
using CRMSystem.DAL.Interfaces;
using CRMSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace CRMSystem.BLL.Dependency
{
    public static class DependencyInjection
    {
        public static void RegisterServices(IUnityContainer container)
        {
            // Register DbContext from DAL
            container.RegisterType<CrmDbContext>();

            // Register DAL repositories
            container.RegisterType<ILeadRepository, LeadRepository>();

            // Register BLL services
            container.RegisterType<ILeadService, LeadService>();

            container.RegisterType<IContactRepository, ContactRepository>();
            container.RegisterType<IContactService, ContactService>();

            container.RegisterType<ISaleRepository, SaleRepository>();
            container.RegisterType<ISaleService, SaleService>();


        }
    }
}
