﻿using Entities.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class TimeWorking : BaseEntity<Guid>
    {
        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        public DateTime MorningStartTime { get; set; }
        public DateTime MorningEndTime { get; set; }
        public DateTime AfternoonStartTime { get; set; }
        public DateTime AfternoonEndTime { get; set; }
        public DateTime ApplyDate { get; set; }
        public DateTime RequestDate { get; set; }
        public Status Status { get; set; }
    }
}