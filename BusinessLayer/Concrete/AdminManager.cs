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

        public Admin TCheckUserNamePassword(string username, string password)
        {
            var admin = _adminDal.CheckUserNamePassword(username, password);
            return admin;
        }

        public Admin TGetAdminByUserName(string username)
        {
            var admin = _adminDal.GetAdminByUserName(username);
            return admin;
        }
    }
}
