using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.DAL.Repos
{
   public class Repo
    {
        protected CrmDbContext db;

        public Repo()
        {
            db = new CrmDbContext();
        }
    }
}
