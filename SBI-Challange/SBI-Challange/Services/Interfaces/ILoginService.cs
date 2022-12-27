using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SBIChallange.Services.Interfaces
{
    public interface ILoginService
    {
        Task<bool> ValidateUser(string username, string password);
    }
}
