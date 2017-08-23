using System;
using System.Linq;
using AnyCore.Core.Domain.ApplicationUser;
using AnyCore.Data;
using System.Collections.Generic;

namespace AnyCore.Services.ApplicationUsers
{
    public partial class ApplicationUserService : IApplicationUserService
    {
        private readonly IRepository<ApplicationUser> _userRepository;

        #region Ctor

        public ApplicationUserService(
            IRepository<ApplicationUser> userRepository)
        {
            this._userRepository = userRepository;
        }

        #endregion

        public void InsertApplicationUser(ApplicationUser applicationUser)
        {
            if (applicationUser == null)
                throw new ArgumentNullException(nameof(applicationUser));

            _userRepository.Insert(applicationUser);
        }


        public IEnumerable<ApplicationUser> GetAll()
        {
            return _userRepository.Table.ToList();
        }

        public ApplicationUser GetApplicationUserById(Guid userId)
        {
            if (userId == Guid.Empty)
                return null;

            var query = from u in _userRepository.Table
                        where u.Id == userId
                        orderby u.Id
                        select u;
            var applicationUser = query.FirstOrDefault();
            return applicationUser;
        }

        public ApplicationUser GetApplicationUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            var query = from u in _userRepository.Table
                        orderby u.Id
                        where u.Email == email
                        select u;
            var applicationUser = query.FirstOrDefault();
            return applicationUser;
        }

        public ApplicationUser GetApplicationUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            var query = from u in _userRepository.Table
                        orderby u.Id
                        where u.Username == username
                        select u;
            var applicationUser = query.FirstOrDefault();
            return applicationUser;
        }

        public void UpdateApplicationUser(ApplicationUser applicationUser)
        {
            if (applicationUser == null)
                throw new ArgumentNullException(nameof(applicationUser));

            _userRepository.Update(applicationUser);
        }
    }
}
