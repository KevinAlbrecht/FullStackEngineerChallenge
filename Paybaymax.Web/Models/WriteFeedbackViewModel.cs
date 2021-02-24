using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paybaymax.Web.Models
{
    public class WriteFeedbackViewModel
    {
        public int QualityRating { get; set; }
        public int InitiativeRating { get; set; }
        public int CooperationRating { get; set; }
        public string Comment { get; set; }
        public Guid PerformanceId { get; set; }
        public Guid CreatorEmployeeId { get; set; }
    }
}
