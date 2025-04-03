using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAdminDal : IRepository<Admin>
    {
        Admin GetAdminByUserName(string username);
        void HashExistingPassword();
        string HashNewPassword(string password);
        bool VerifyPassword(string hashedPassword, string enteredPassword);
    }
}
