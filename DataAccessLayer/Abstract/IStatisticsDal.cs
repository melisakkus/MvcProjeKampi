using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IStatisticsDal 
    {
        int CategoryCount();
        int HeadingCountWithSoftware();
        int WriterNameCountWithA();
        Category MaxCategory();
        int DifferenceBtTrueFalseCategory();

        List<StatisticsCategory> CategoryList();
        List<StatisticsWriter> WriterContentList();

    }
}
