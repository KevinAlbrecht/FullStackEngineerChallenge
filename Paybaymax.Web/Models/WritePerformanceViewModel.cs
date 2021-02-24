using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paybaymax.Web.Models
{
    public class WritePerformanceViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid Concerned { get; set; }
    }
}
