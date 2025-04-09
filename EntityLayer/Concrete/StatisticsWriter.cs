using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [NotMapped]
    public class StatisticsWriter
    {
        public string WriterName { get; set; }
        public int ContentCount { get; set; }
    }
}
