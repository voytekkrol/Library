using Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataAccess.Data.Repository.IRepository
{
    interface IUserRepository : IRepository<ApplicationUser>
    {
        void LockUser(string userId);

        void UnLockUser(string userId);
    }
}
