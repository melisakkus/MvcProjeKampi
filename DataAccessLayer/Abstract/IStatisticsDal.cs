using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IStatisticsDal 
    {
        int CategoryCount();
        int HeadingCountWithSoftware();
        int WriterNameCountWithA();
        Category MaxCategory();
        int DifferenceBtTrueFalseCategory();
    }
}
