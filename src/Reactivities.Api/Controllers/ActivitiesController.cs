using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reactivities.Application.Interfaces;
using Reactivities.Domain.Entities;

namespace Reactivities.Api.Controllers
{
    public class ActivitiesController : BaseController
    {
        private readonly IActivityService _activityService;
        
        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            var result = await _activityService.GetActivities();

            return Result(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            var result = await _activityService.GetActivityById(id);

            return Result(result);
        }
    }
}