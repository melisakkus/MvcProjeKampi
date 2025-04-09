using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        void ContentAddBL(Content p);
        Content GetById(int id);
        void RemoveContent(Content model);
        void ContentUpdate(Content model);

        List<Content> GetListByHeadingId(int id);
        List<Content> GetListByWriter(int id);
        List<Content> GetSearchContents(string searchValue);
        List<Content> GetLast();

    }
}
