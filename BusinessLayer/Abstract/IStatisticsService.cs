using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStatisticsService
    {
        int TCategoryCount();
        int THeadingCountWithSoftware();
        int TWriterNameCountWithA();
        Category TMaxCategory();
        int TDifferenceBtTrueFalseCategory();
    }
}
