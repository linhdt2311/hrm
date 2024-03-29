﻿using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Database;

namespace Business.SignalR
{
    public class PresenceHub : Hub
    {
        private readonly PresenceTracker _tracker;

        public PresenceHub(PresenceTracker tracker, DataContext dataContext)
        {
            _tracker = tracker;
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var userId = httpContext.Request.Query["userId"].ToString();

            var isOnline = await _tracker.UserConnected(Context.User.Identity.Name, Context.ConnectionId);
            if (isOnline)
            {
                await Clients.Others.SendAsync("UserIsOnline", Context.User.Identity.Name);
            }

            /*var notifies = await _dataContext.Notification.Where(n => n.EmployeeId == Guid.Parse(userId)).OrderByDescending(n => n.CreateDate).ToListAsync();
            await Clients.Caller.SendAsync("Notification", notifies);

            var count = await _dataContext.Notification.Where(n => n.EmployeeId == Guid.Parse(userId) && n.IsRead == false).CountAsync();
            await Clients.Caller.SendAsync("UnreadNotificationNumber", count);*/

            var currentUsers = await _tracker.GetOnlineUsers();
            await Clients.Caller.SendAsync("GetOnlineUsers", currentUsers);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {

            var isOffline = await _tracker.UserDisconnected(Context.User.Identity.Name, Context.ConnectionId);
            if (isOffline)
            {
                await Clients.Others.SendAsync("UserIsOffline", Context.User.Identity.Name);
            }

            await base.OnDisconnectedAsync(exception);
        }

        /*public async Task CreateTask(CreateOrEditTaskDto input)
        {
            var task = await _dataContext.Tasks.AsNoTracking().FirstOrDefaultAsync(e => e.ProjectId == input.ProjectId
                && e.TaskName.ToLower() == input.TaskName.ToLower());
            if (task != null) throw new HubException("TaskName was existed");
            var project = await _dataContext.Project.FindAsync(input.ProjectId);
            var leader = await _dataContext.Employee.FindAsync(input.CreateUserId);
            var emp = await _dataContext.Employee.FindAsync(input.EmployeeId);
            if (input.DeadlineDate.Date > project.DeadlineDate.Date)
            {
                throw new HubException("Task deadline date must less than or equal porject deadline date");
            }
            else
            {
                var newTask = new Tasks
                {
                    Id = new Guid(),
                    TaskName = input.TaskName,
                    CreateUserId = input.CreateUserId,
                    CreateDate = DateTime.Now,
                    DeadlineDate = input.DeadlineDate,
                    PriorityCode = input.PriorityCode,
                    StatusCode = Enum.StatusTask.Open,
                    Description = input.Description,
                    TaskType = input.TaskType,
                    TaskCode = input.TaskCode,
                    ProjectId = input.ProjectId,
                    EmployeeId = input.EmployeeId
                };
                await _dataContext.Tasks.AddAsync(newTask);
                await _dataContext.SaveChangesAsync();

                var notify = new Notification
                {
                    Id = new Guid(),
                    Content = "You have a new task in " + project.ProjectName + " project",
                    EmployeeId = newTask.EmployeeId,
                    CreateDate = DateTime.Now,
                    IsRead = false,
                    AnyId = newTask.Id,
                };

                await _dataContext.Notification.AddAsync(notify);
                await _dataContext.SaveChangesAsync();

                var connections = await _tracker.GetConnectionsForUser(emp.FullName);
                if (connections != null)
                {
                    var notifies = await _dataContext.Notification.Where(n => n.EmployeeId == emp.Id).OrderByDescending(n => n.CreateDate).ToListAsync();
                    await Clients.Caller.SendAsync("Notification", notifies);
                    await Clients.Clients(connections).SendAsync("NewTaskReceived", notify);
                    var count = await _dataContext.Notification.Where(n => n.EmployeeId == input.EmployeeId && n.IsRead == false).CountAsync();
                    await Clients.Clients(connections).SendAsync("UnreadNotificationNumber", count);
                }
            }
        }*/

        /*public async Task ReadNotification(UnreadNotifiesDto input)
        {
            var notify = await _dataContext.Notification.FindAsync(input.Id);
            var user = await _dataContext.Employee.FindAsync(input.EmployeeId);
            notify.IsRead = true;
            await _dataContext.SaveChangesAsync();

            var connections = await _tracker.GetConnectionsForUser(user.FullName);
            if (connections != null)
            {
                var notifies = await _dataContext.Notification.Where(n => n.EmployeeId == input.EmployeeId).OrderByDescending(n => n.CreateDate).ToListAsync();
                await Clients.Clients(connections).SendAsync("Notification", notifies);
                await Clients.Clients(connections).SendAsync("NewTaskReceived", notify);
                var count = await _dataContext.Notification.Where(n => n.EmployeeId == input.EmployeeId && n.IsRead == false).CountAsync();
                await Clients.Clients(connections).SendAsync("UnreadNotificationNumber", count);
            }
        }*/

        private string GetGroupName(string caller, string other)
        {
            var stringCompare = string.CompareOrdinal(caller, other) < 0;
            return stringCompare ? $"{caller}-{other}" : $"{other}-{caller}";
        }
    }
}
