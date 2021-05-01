using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reactivities.Domain.Entities;

namespace Reactivities.Application.Interfaces
{
    public interface IActivityService
    {
        Task<List<Activity>> GetActivities();
        Task<Activity> GetActivityById(Guid id);
    }
}