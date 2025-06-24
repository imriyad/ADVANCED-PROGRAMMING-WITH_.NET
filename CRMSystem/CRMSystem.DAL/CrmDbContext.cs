using CRMSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.DAL
{
    public class CrmDbContext: DbContext
    {
        public CrmDbContext() : base("name=CrmDbContext")
        {
            // Fix for EF provider error in class library
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Lead> Leads { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Sale> Sales { get; set; }

        public DbSet<User> Users { get; set; }


    }
}
