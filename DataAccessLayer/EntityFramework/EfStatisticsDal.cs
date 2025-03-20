using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfStatisticsDal : IStatisticsDal
    {
        Context context = new Context();

        public int CategoryCount()
        {
            return context.Categories.Count();
        }

        public int DifferenceBtTrueFalseCategory()
        {
            var trueCount = context.Categories.Where(x => x.CategoryStatus == true).Count();
            var falseCount = context.Categories.Where(x => x.CategoryStatus == false).Count();
            return trueCount - falseCount;
        }

        public int HeadingCountWithSoftware()
        {
            var values = context.Headings.Where(x => x.Category.CategoryName == "Yazılım").Count();
            return values;
        }

        public Category MaxCategory()
        {
            var category = context.Categories.OrderByDescending(x=>x.Headings.Count()).FirstOrDefault();
            return category;
        }

        public int WriterNameCountWithA()
        {
            var values = context.Writers.Where(x => x.WriterName.Contains("a") ||x.WriterName.Contains("A")).Count();
            return values;
        }
    }
}
