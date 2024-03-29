﻿using System;

namespace Business.DTOs.DepartmentDto
{
    public class CreateOrEditDepartmentDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public Guid Boss { get; set; }
    }
}
