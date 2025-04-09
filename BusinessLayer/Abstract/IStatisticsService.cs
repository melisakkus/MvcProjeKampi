using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IStatisticsService
    {
        int TCategoryCount();
        int THeadingCountWithSoftware();
        int TWriterNameCountWithA();
        Category TMaxCategory();
        int TDifferenceBtTrueFalseCategory();
        List<StatisticsCategory> TCategoryList();
        List<StatisticsWriter> TWriterContentList();


    }
}
