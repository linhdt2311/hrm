﻿using HRM.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.Entities
{
    public class TimeWorking
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        public DateTime MorningStartTime { get; set; }
        public DateTime MorningEndTime { get; set; }
        public DateTime AfternoonStartTime { get; set; }
        public DateTime AfternoonEndTime { get; set; }
        public DateTime ApplyDate { get; set; }
        public Status Status { get; set; }
    }
}
