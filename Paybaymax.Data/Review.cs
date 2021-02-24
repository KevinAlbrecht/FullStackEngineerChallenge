using System;
using System.Collections.Generic;

#nullable disable

namespace Paybaymax.Data
{
    public partial class Review
    {
        public Guid Id { get; set; }
        public byte GlobalRating { get; set; }
        public byte QualityRating { get; set; }
        public byte InitiativeRating { get; set; }
        public byte CooperationRating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid PerformanceId { get; set; }
        public Guid CreatorEmployeeId { get; set; }

        public virtual Employee CreatorEmployee { get; set; }
        public virtual Performance Performance { get; set; }
    }
}
