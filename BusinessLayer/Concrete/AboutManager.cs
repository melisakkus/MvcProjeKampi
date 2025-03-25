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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AboutAddBL(About about)
        {
            _aboutDal.Insert(about);
        }

        public void AboutUpdate(About model)
        {
            _aboutDal.Update(model);
        }

        public About GetById(int id)
        {
            return _aboutDal.Get(x=>x.AboutId==id);
        }

        public List<About> GetList()
        {
            return _aboutDal.List();
        }

        public void RemoveAbout(About model)
        {
            _aboutDal.Delete(model);
        }
    }
}
