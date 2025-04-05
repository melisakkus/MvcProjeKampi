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
    public class ContentManager : IContentService
    {
        private readonly IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAddBL(Content p)
        {
            _contentDal.Insert(p);
        }

        public void ContentUpdate(Content model)
        {
            _contentDal.Update(model);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(x=>x.ContentId == id);
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _contentDal.List(x => x.HeadingId == id);
        }

        public List<Content> GetList()
        {
            return _contentDal.List();
        }

        public void RemoveContent(Content model)
        {
            _contentDal.Delete(model);
        }

        public List<Content> GetListByWriter(int id)
        {
           return _contentDal.List(x => x.WriterId == id);
        }
    }
}
