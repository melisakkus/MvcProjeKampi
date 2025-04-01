using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {
        public Admin GetAdminByUserName(string username)
        {
            var admin = _object.FirstOrDefault(x => x.AdminUserName == username);
            return admin;
        }

        public Admin CheckUserNamePassword(string username, string password)
        {
            var admin = _object.FirstOrDefault(x=>x.AdminUserName == username && x.AdminPassword == password);
            return admin;
        }
    }
}
