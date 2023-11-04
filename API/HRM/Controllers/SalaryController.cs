﻿using Business.DTOs.SalaryDto;
using CoreApiResponse;
using Database;
using Entities;
using Entities.Enum;
using Entities.Enum.Record;
using Entities.Enum.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Controllers
{
    public class SalaryController : BaseApiController
    {
        private readonly DataContext _dataContext;
        private readonly ISession _session;

        public SalaryController(DataContext dataContext, ISession session)
        {
            _dataContext = dataContext;
            _session = session;
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _dataContext.Salary.AsNoTracking().ToListAsync();
            return CustomResult(list);
        }
        [HttpGet("getAllSalaryForEmployee")]
        public async Task<IActionResult> GetAllSalaryForEmployee(int month, int year)
        {
            var userList = await _dataContext.SalaryReport.Where(i => i.Date.Month - 1 == month && i.Date.Year == year).AsNoTracking().ToListAsync();
            return CustomResult(userList);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateSalaryDto input)
        {
            var salary = new Salary
            {
                Id = new System.Guid(),
                CreatorUserId = new Guid(_session.GetString("UserId")),
                SalaryCode = Random(input),
                Level = input.Level,
                PositionId = input.PositionId,
                Money = input.Money,
                Welfare = input.Welfare,
            };
            await _dataContext.AddAsync(salary);
            await _dataContext.SaveChangesAsync();
            return CustomResult(salary);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateSalaryDto input)
        {
            var salary = await _dataContext.SalaryReport.FindAsync(input.Id);
            if (salary != null)
            {
                salary.LastModifierUserId = new Guid(_session.GetString("UserId"));
                salary.Salary = input.Salary;
                salary.Date = input.Date;
                salary.TotalWorkdays = input.TotalWorkdays;
                salary.Punish = input.Punish;
                salary.Bounty = input.Bounty;
                salary.ActualSalary = input.ActualSalary;
            }
            _dataContext.Update(salary);
            await _dataContext.SaveChangesAsync();
            return CustomResult(salary);
        }
        [HttpPost("sendNotificationSalary")]
        public async Task<IActionResult> SendNotificationSalary(SendNotificationSalaryDto input)
        {
            var notification = new Notification
            {
                Id = new Guid(),
                Thumbnail = "https://pyjamahr.com/wp-content/uploads/2022/03/WhatsApp-Image-2022-03-03-at-12.39.41.jpeg",
                Title = "Notice of salary statistics for the month of " + CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(input.Month),
                Content = "",
                Type = "Salary",
                CreateDate = DateTime.Now,
                CreatorUserId = new Guid(_session.GetString("UserId")),
            };
            await _dataContext.Notification.AddAsync(notification);
            foreach (var i in input.Employee)
            {
                var employee = new NotificationEmployee
                {
                    Id = new Guid(),
                    NotificationId = notification.Id,
                    EmployeeId = i.EmployeeId,
                    IsRead = false,
                    CreatorUserId = new Guid(_session.GetString("UserId")),
                };
                await _dataContext.AddAsync(employee);
            }
            await _dataContext.SaveChangesAsync();
            var result = new
            {
                Id = notification.Id,
                Thumbnail = notification.Thumbnail,
                Title = notification.Title,
                Content = notification.Content,
                CreateDate = notification.CreateDate,
            };
            return CustomResult(result);
        }
        [HttpPut("confirmSalary")]
        public async Task<IActionResult> ConfirmSalary(Guid salaryId, ConfirmStatus confirm)
        {
            var salary = await _dataContext.SalaryReport.FindAsync(salaryId);
            if (salary != null)
            {
                salary.IsConfirm = confirm;
                salary.LastModifierUserId = new Guid(_session.GetString("UserId"));
                _dataContext.SalaryReport.Update(salary);
                await _dataContext.SaveChangesAsync();
            }
            return CustomResult(salary);
        }
        [HttpGet("getSalaryForEmployee")]
        public async Task<IActionResult> GetSalaryForEmployee()
        {
            var list = await (from s in _dataContext.SalaryReport
                              join e in _dataContext.Employee on s.UserId equals e.Id
                              where e.IsDeleted == false
                              select s).AsNoTracking().ToListAsync();
            return CustomResult(list);
        }
        [HttpPut("updateSalaryForEmployee/{employeeId}")]
        public async Task<IActionResult> UpdateSalaryForEmployee(Guid employeeId, Guid salaryId)
        {
            var salary = await _dataContext.SalaryReport.FirstOrDefaultAsync(i => i.UserId == employeeId);
            if (salary != null)
            {
                salary.Salary = salaryId;
                _dataContext.SalaryReport.Update(salary);
                await _dataContext.SaveChangesAsync();
            }
            return CustomResult();
        }
        public static string Random(CreateSalaryDto input)
        {
            string randomStr = "0" + input.PositionId;
            switch (input.Level)
            {
                case Level.Intern:
                    randomStr += "01";
                    break;
                case Level.Fresher:
                    randomStr += "02";
                    break;
                case Level.Middle:
                    randomStr += "03";
                    break;
                case Level.Junior:
                    randomStr += "04";
                    break;
                case Level.Senior:
                    randomStr += "05";
                    break;
            }
            randomStr += DateTime.Now.ToString("MM");
            randomStr += DateTime.Now.ToString("yy");
            try
            {
                int[] myIntArray = new int[4];
                int x;
                //that is to create the random # and add it to uour string
                Random autoRand = new Random();
                for (x = 0; x < 4; x++)
                {
                    myIntArray[x] = System.Convert.ToInt32(autoRand.Next(0, 9));
                    randomStr += (myIntArray[x].ToString());
                }
            }
            catch (Exception ex)
            {
                randomStr = "error";
            }
            return randomStr;
        }

    }
}
