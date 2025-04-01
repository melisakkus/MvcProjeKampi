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
        Admin TCheckUserNamePassword(string username, string password);
        Admin TGetAdminByUserName(string username);

    }
}
