using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void TAddAdmin(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public List<Admin> TAdminList()
        {
            return _adminDal.List();
        }

        public Admin TGetAdmin(int id)
        {
            return _adminDal.Get(x => x.AdminId == id);
        }

        public Admin TGetAdminByUserName(string username)
        {
            var admin = _adminDal.GetAdminByUserName(username);
            return admin;
        }

        public void THashExistingPassword()
        {
            _adminDal.HashExistingPassword();
        }

        public string THashNewPassword(string password)
        {
            return _adminDal.HashNewPassword(password);
        }

        public void TRemoveAdmin(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public void TUpdateAdmin(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public bool TVerifyPassword(string hashedPassword, string enteredPassword)
        {
            return _adminDal.VerifyPassword(hashedPassword, enteredPassword);
        }
    }
}
