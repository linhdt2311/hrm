﻿using HRM.Data;
using HRM.DTOs.EmployeeDto;
using HRM.Entities;
using HRM.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using HRM.DTOs.OnLeaveDto;
using CoreApiResponse;

namespace HRM.Controllers
{
    [ApiController]
    [Route("api/onleave")]
    public class OnLeaveController : BaseController
    {
        private readonly DataContext _dataContext;

        public OnLeaveController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _dataContext.OnLeave.AsNoTracking().ToListAsync();
            return CustomResult(list);
        }
        [HttpPost("requestLeave")]
        public async Task<IActionResult> Create(CreateOrEditOnLeaveDto input)
        {
            foreach (var i in input.OnLeave)
            {
                var checkLeave = await _dataContext.OnLeave.AsNoTracking().FirstOrDefaultAsync(e => e.EmployeeId == input.EmployeeId && e.DateLeave == i.DateLeave);
                if (checkLeave != null)
                {
                    checkLeave.Option = i.Option;
                    checkLeave.Reason = i.Reason;
                    _dataContext.OnLeave.Update(checkLeave);
                }
                else
                {
                    var onLeave = new OnLeave
                    {
                        Id = new Guid(),
                        EmployeeId = input.EmployeeId,
                        DateLeave = i.DateLeave,
                        Option = i.Option,
                        Reason = i.Reason,
                        Status = Status.Pending,
                    };
                    await _dataContext.OnLeave.AddAsync(onLeave);
                }
            };
            await _dataContext.SaveChangesAsync();
            return CustomResult(input);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _dataContext.OnLeave.Remove(await _dataContext.OnLeave.FindAsync(id));
            await _dataContext.SaveChangesAsync();
            return CustomResult(id);
        }
    }
}
