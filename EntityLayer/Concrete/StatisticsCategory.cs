using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [NotMapped]
    public class StatisticsCategory
    {
        public string CategoryName { get; set; }
        public int CategoryCount { get; set; }
    }
}
