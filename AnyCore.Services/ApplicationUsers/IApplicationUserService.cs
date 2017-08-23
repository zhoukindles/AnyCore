using AnyCore.Core.Domain.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnyCore.Services.ApplicationUsers
{
    public interface IApplicationUserService
    {
        void InsertApplicationUser(ApplicationUser applicationUser);

        IEnumerable<ApplicationUser> GetAll();

        ApplicationUser GetApplicationUserById(Guid useId);


        ApplicationUser GetApplicationUserByEmail(string email);


        ApplicationUser GetApplicationUserByUsername(string username);

        void UpdateApplicationUser(ApplicationUser applicationUser);
    }
}
