using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reactivities.Application.Interfaces;
using Reactivities.Domain.Entities;
using Reactivities.Infra.Context;

namespace Reactivities.Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly DataContext _context;
        private readonly ILogger<ActivityService> _logger;

        public ActivityService(DataContext context, ILogger<ActivityService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Activity>> GetActivities()
        {
            try
            {
                var activities = await _context.Activities.ToListAsync();

                return activities;
            }
            catch (Exception e)
            {
                _logger.LogError("An error occured with get activities");
                throw new HttpRequestException(e.Message);
            }
        }

        public async Task<Activity> GetActivityById(Guid id)
        {
            try
            {
                var activity = await _context.Activities.FindAsync(id);

                if (activity == null)
                {
                    throw new FileNotFoundException($"Activity with ID: {id} was not found");
                }

                return activity;
            }
            catch (Exception e)
            {
                _logger.LogError("An error occured with get activity by id");
                throw new HttpRequestException(e.Message);
            }
        }
    }
}