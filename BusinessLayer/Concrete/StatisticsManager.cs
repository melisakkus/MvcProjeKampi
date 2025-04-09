using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class StatisticsManager : IStatisticsService
    {
        private readonly IStatisticsDal _statisticsDal;

        public StatisticsManager(IStatisticsDal statisticsDal)
        {
            _statisticsDal = statisticsDal;
        }

        public int TCategoryCount()
        {
            return _statisticsDal.CategoryCount();
        }

        public List<StatisticsCategory> TCategoryList()
        {
            return _statisticsDal.CategoryList();
        }

        public int TDifferenceBtTrueFalseCategory()
        {
            return _statisticsDal.DifferenceBtTrueFalseCategory();
        }

        public int THeadingCountWithSoftware()
        {
            return _statisticsDal.HeadingCountWithSoftware();
        }

        public Category TMaxCategory()
        {
            return _statisticsDal.MaxCategory();
        }

        public List<StatisticsWriter> TWriterContentList()
        {
            return _statisticsDal.WriterContentList();
        }

        public int TWriterNameCountWithA()
        {
            return _statisticsDal.WriterNameCountWithA();
        }

    }
}
