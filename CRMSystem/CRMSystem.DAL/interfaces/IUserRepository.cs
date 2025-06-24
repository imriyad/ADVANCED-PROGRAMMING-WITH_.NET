using CRMSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.DAL.interfaces
{
    public interface IUserRepository
    {
        User GetByEmail(string email);

        void Add(User user);
    }
}
