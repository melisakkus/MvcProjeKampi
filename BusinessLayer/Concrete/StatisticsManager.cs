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

        public int TWriterNameCountWithA()
        {
            return _statisticsDal.WriterNameCountWithA();
        }
    }
}
