﻿using Entities.Enum;
using Entities.Enum.User;
using System;

namespace Business.DTOs.AccountDto
{
    public class GetAccountDto
    {
        public Guid Id { get; set; }
        public List<AccRole> Role { get; set; }
        public string? Avatar { get; set; }
        public string? FullName { get; set; }
        public bool Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime DoB { get; set; }
        public Level Level { get; set; }
        public Guid? PositionId { get; set; }
        public string? PositionName { get; set; }
        public string? PositionColor { get; set; }
        public Guid? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentColor { get; set; }
        public DateTime StartingDate { get; set; }
        public string? Bank { get; set; }
        public string? BankAccount { get; set; }
        public string? TaxCode { get; set; }
        public string? InsuranceStatus { get; set; }
        public string? Identify { get; set; }
        public string? PlaceOfOrigin { get; set; }
        public string? PlaceOfResidence { get; set; }
        public string? DateOfIssue { get; set; }
        public string? IssuedBy { get; set; }
        public string? UserCode { get; set; }
        public string? Token { get; set; }
    }
    public class AccRole
    {
        public string RoleName { get; set; }
    }
}
