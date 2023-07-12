﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Payoff : BaseEntity<Guid>
    {
        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        public string? Reason { get; set; }
        public int Amount { get; set; }
        public bool Punish { get; set; }
        public DateTime Date { get; set; }
    }
}