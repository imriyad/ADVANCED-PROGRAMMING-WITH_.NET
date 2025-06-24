using CRMSystem.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.BLL.interfaces
{
    public interface IUserService
    {
        UserDTO Authenticate(string email, string password);

        void Register(RegisterRequestDTO registerRequest);
    }
}
