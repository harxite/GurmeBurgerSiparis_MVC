using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstracts
{
    public interface IAuthService
    {
        public Task<bool> EmailConfirmTokenAsync(string email);
        Task<bool> VerifyEmailConfirmTokenAsync(string userId, string confirmationToken);
    }
}
