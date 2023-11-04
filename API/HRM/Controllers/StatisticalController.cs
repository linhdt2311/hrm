﻿using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.OpenApi.Any;
using System.Numerics;
using Database;
using Entities.Enum;
using Business.DTOs.StatisticalDto;
using Entities;
using Entities.Enum.Record;

namespace HRM.Controllers
{
    public class StatisticalController : BaseApiController
    {
        private readonly DataContext _dataContext;

        public StatisticalController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet("totalEmployee")]
        public async Task<IActionResult> GetAll()
        {
            var payoffList = await _dataContext.PayOff.Where(i => i.IsDeleted == false && ((DateTime)i.CreationTime).Month == DateTime.Now.Month).AsNoTracking().ToListAsync();
            int totalPunish = 0;
            int totalBounty = 0;
            foreach (var i in payoffList)
            {
                if (i.Punish == false)
                {
                    totalPunish += i.Amount;
                }
                else
                {
                    totalBounty += i.Amount;
                }
            }
            var result = new
            {
                totalEmployee = new
                {
                    total = _dataContext.Employee.Where(i => i.Status == RecordStatus.Approved && !i.IsActive).AsNoTracking().ToList().Count,
                    percent = 100 - (int)Math.Round((double)(100 * _dataContext.Employee.Where(i => i.Status == RecordStatus.Approved && !i.IsActive && ((DateTime)i.CreationTime).Month != DateTime.Now.Month).AsNoTracking().ToList().Count) /
                        _dataContext.Employee.Where(i => i.Status == RecordStatus.Approved && !i.IsActive).AsNoTracking().ToList().Count),
                },
                totalLeave = new
                {
                    total = _dataContext.Employee.Where(i => i.Status == RecordStatus.Approved && i.IsActive && ((DateTime)i.LastModificationTime).Month == DateTime.Now.Month).AsNoTracking().ToList().Count,
                    percent = 100 - (int)Math.Round((double)(100 * _dataContext.Employee.Where(i => i.Status == RecordStatus.Approved && i.IsActive && (((DateTime)i.LastModificationTime).Month - 1) == (DateTime.Now.Month - 1)).AsNoTracking().ToList().Count) /
                        _dataContext.Employee.Where(i => i.Status == RecordStatus.Approved && i.IsActive && ((DateTime)i.LastModificationTime).Month == DateTime.Now.Month).AsNoTracking().ToList().Count),
                },
                totalNewEmployee = new
                {
                    total = _dataContext.Employee.Where(i => i.Status == RecordStatus.Approved && i.IsActive && ((DateTime)i.CreationTime).Month == DateTime.Now.Month).AsNoTracking().ToList().Count,
                    percent = 100 - (int)Math.Round((double)(100 * _dataContext.Employee.Where(i => i.Status == RecordStatus.Approved && i.IsActive && (((DateTime)i.CreationTime).Month - 1) == (DateTime.Now.Month - 1)).AsNoTracking().ToList().Count) /
                        _dataContext.Employee.Where(i => i.Status == RecordStatus.Approved && i.IsActive && ((DateTime)i.CreationTime).Month == DateTime.Now.Month).AsNoTracking().ToList().Count),
                },
                totalRequestUpdateProfile = _dataContext.Employee.Where(i => i.Status != RecordStatus.Approved && !i.IsActive && ((DateTime)i.CreationTime).Month == DateTime.Now.Month).AsNoTracking().ToList().Count,
                totalRequestChangeWorkingTime = _dataContext.TimeWorking.Where(i => i.Status != RecordStatus.Approved && ((DateTime)i.CreationTime).Month == DateTime.Now.Month).AsNoTracking().ToList().Count,
                totalRequestOff = _dataContext.RequestOff.Where(i => i.Status != RecordStatus.Approved && i.Option != OptionRequest.Late && i.Option != OptionRequest.LeaveEarly && ((DateTime)i.DayOff).Month == DateTime.Now.Month).AsNoTracking().ToList().Count,
                totalRequestLateOrLeaveEarly = _dataContext.RequestOff.Where(i => i.Status != RecordStatus.Approved && i.Option == OptionRequest.Late && i.Option == OptionRequest.LeaveEarly && ((DateTime)i.DayOff).Month == DateTime.Now.Month).AsNoTracking().ToList().Count,
                totalPunish = totalPunish,
                totalBounty = totalBounty,
                totalEmployeeUpLevel = new
                {
                    total = _dataContext.Evaluate.Where(i => i.NewLevel > i.OldLevel && ((DateTime)i.CreationTime).Month == DateTime.Now.Month).AsNoTracking().ToList().Count,
                    percent = 100 - (int)Math.Round((double)(100 * _dataContext.Evaluate.Where(i => i.NewLevel > i.OldLevel && (((DateTime)i.CreationTime).Month - 1) == (DateTime.Now.Month - 1)).AsNoTracking().ToList().Count) /
                        _dataContext.Evaluate.Where(i => i.NewLevel > i.OldLevel && ((DateTime)i.CreationTime).Month == DateTime.Now.Month).AsNoTracking().ToList().Count),
                },
            };
            return CustomResult(result);
        }
        [HttpGet("payoffForMonth")]
        public async Task<IActionResult> PayoffForMonth()
        {
            var result = new List<PayOffForMonthDto>();
            for (int j = 1; j <= 12; j++)
            {
                var payoffList = await _dataContext.PayOff.Where(i => i.IsDeleted == false && ((DateTime)i.CreationTime).Month == j).AsNoTracking().ToListAsync();
                int totalPunish = 0;
                int totalBounty = 0;
                foreach (var i in payoffList)
                {
                    if (i.Punish == false)
                    {
                        totalPunish += i.Amount;
                    }
                    else
                    {
                        totalBounty += i.Amount;
                    }
                }
                var item = new PayOffForMonthDto
                {
                    Month = j,
                    Punish = totalPunish,
                    Bounty = totalBounty,
                };
                result.Add(item);
            }
            return CustomResult(result);
        }
        [HttpGet("getAllEmployeeUpLevel")]
        public async Task<IActionResult> getAllEmployeeUpLevel()
        {
            var result = _dataContext.Evaluate.Where(i => i.NewLevel > i.OldLevel && ((DateTime)i.CreationTime).Month == DateTime.Now.Month).AsNoTracking().ToList();
            var list = new List<Employee>();
            foreach (var i in result)
            {
                list.Add(_dataContext.Employee.Find(i.UserId));
            }
            return CustomResult(list);
        }
    }
}
