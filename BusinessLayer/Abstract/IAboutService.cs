using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();
        About GetById(int id);
        void AboutAddBL(About about);
        void RemoveAbout(About model);
        void AboutUpdate(About model);

    }
}
