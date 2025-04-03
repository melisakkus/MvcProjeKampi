using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> TAdminList();

        Admin TGetAdmin(int id);
        void TAddAdmin(Admin admin);
        void TRemoveAdmin(Admin admin);
        void TUpdateAdmin(Admin admin);



        Admin TGetAdminByUserName(string username);

        void THashExistingPassword();
        string THashNewPassword(string password);
        bool TVerifyPassword(string hashedPassword, string enteredPassword);
    }
}
