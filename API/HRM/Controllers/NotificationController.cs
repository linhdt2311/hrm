﻿using CoreApiResponse;
using HRM.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HRM.DTOs.EmployeeDto;
using HRM.DTOs.NotificationDto;
using HRM.Entities;

namespace HRM.Controllers
{
    [ApiController]
    [Route("api/notification")]
    public class NotificationController : BaseController
    {
        private readonly DataContext _dataContext;

        public NotificationController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet("getAll/{id}")]
        public async Task<IActionResult> GetAll(Guid id)
        {
            var notificationList = await (from n in _dataContext.Notification
                                          join e in _dataContext.NotificationEmployee
                                          on n.Id equals e.NotificationId
                                          where e.EmployeeId == id
                                          select new
                                          {
                                              Id = e.Id,
                                              Thumbnail = n.Thumbnail,
                                              Title = n.Title,
                                              CreateDate = n.CreateDate,
                                              IsRead = e.IsRead,
                                          }).AsNoTracking().ToListAsync();
            return CustomResult(notificationList);
        }
        [HttpGet("readNotification/{employeeId}")]
        public async Task<IActionResult> ReadNotification(Guid employeeId, Guid id)
        {
            var notification = await _dataContext.NotificationEmployee.FirstOrDefaultAsync(e => e.NotificationId == id && e.EmployeeId == employeeId);
            if (notification != null)
            {
                notification.IsRead = true;
                _dataContext.NotificationEmployee.Update(notification);
                await _dataContext.SaveChangesAsync();
            }
            var result = from n in _dataContext.Notification
                         where n.Id == id
                         select new
                         {
                             Id = n.Id,
                             Thumbnail = n.Thumbnail,
                             Title = n.Title,
                             Content = n.Content,
                             CreateDate = n.CreateDate,
                             IsRead = notification.IsRead,
                         };
            return CustomResult(result);
        }

        [HttpPost("save")]
        public async Task<IActionResult> CreateOrEdit(CreateOrEditNotificationDto input)
        {
            if (input.Id == null)
            {
                return await Create(input);
            }
            else
            {
                return await Update(input);
            }
        }
        private async Task<IActionResult> Create(CreateOrEditNotificationDto input)
        {
            var notification = new Notification
            {
                Id = new Guid(),
                Thumbnail = input.Thumbnail,
                Title = input.Title,
                Content = input.Content,
                CreateDate = input.CreateDate,
                CreatorUserId = input.ActionId,
            };
            await _dataContext.AddAsync(notification);
            foreach (var i in input.Employee)
            {
                var employee = new NotificationEmployee
                {
                    Id = new Guid(),
                    NotificationId = notification.Id,
                    EmployeeId = i.EmployeeId,
                    IsRead = false,
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
                Employee = input.Employee,
            };
            return CustomResult(result);
        }
        private async Task<IActionResult> Update(CreateOrEditNotificationDto input)
        {
            var notification = await _dataContext.Notification.FindAsync(input.Id);
            if (notification != null)
            {
                notification.Thumbnail = input.Thumbnail;
                notification.Title = input.Title;
                notification.Content = input.Content;
                notification.CreateDate = input.CreateDate;
                notification.CreatorUserId = input.ActionId;
                _dataContext.Update(notification);
                var employee = await (from n in _dataContext.NotificationEmployee
                                      where n.NotificationId == input.Id
                                      select new
                                      {
                                          EmployeeId = n.EmployeeId,
                                      }).AsNoTracking().ToListAsync();
                foreach (var i in input.Employee)
                {
                    var check = employee.Find(m => m.EmployeeId == i.EmployeeId);
                    if (check == null)
                    {
                        var newItem = new NotificationEmployee
                        {
                            Id = new Guid(),
                            NotificationId = input.Id,
                            EmployeeId = i.EmployeeId,
                            IsRead = false,
                        };
                        _dataContext.NotificationEmployee.Update(newItem);
                    }
                };
                foreach (var i in employee)
                {
                    var check = input.Employee.Find(m => m.EmployeeId == i.EmployeeId);
                    if (check == null)
                    {
                        _dataContext.NotificationEmployee.Remove(
                            await _dataContext.NotificationEmployee.FirstOrDefaultAsync(n => n.NotificationId == input.Id && n.EmployeeId == i.EmployeeId && n.IsDeleted == false));
                    }
                }
            }
            await _dataContext.SaveChangesAsync();
            var result = new
            {
                Id = notification.Id,
                Thumbnail = notification.Thumbnail,
                Title = notification.Title,
                Content = notification.Content,
                CreateDate = notification.CreateDate,
                Employee = input.Employee,
            };
            return CustomResult(result);
        }
    }
}