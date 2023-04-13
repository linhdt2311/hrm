﻿using HRM.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM.DTOs.TaskDto
{
    public class CreateOrEditTaskDto
    {
        public Guid? Id { get; set; }
        public string TaskName { get; set; }
        public Guid CreateUserId { get; set; }
        public DateTime DeadlineDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public Priority PriorityCode { get; set; }
        public StatusTask StatusCode { get; set; }
        public string Description { get; set; }
        public string TaskType { get; set; }
        public string TaskCode { get; set; }
        public string ReasonForDelay { get; set; }
        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }
    }
}