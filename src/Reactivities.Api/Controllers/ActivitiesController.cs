using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reactivities.Application.Activities;
using Reactivities.Domain.Entities;

namespace Reactivities.Api.Controllers
{
    public class ActivitiesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            var result = await Mediator.Send(new ListActivity.Query());

            return Result(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            var result = await Mediator.Send(new DetailActivity.Query{ Id = id});

            return Result(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            await Mediator.Send(new CreateActivity.Command { Activity = activity });
            
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(Guid id, Activity activity)
        {
            await Mediator.Send(new UpdateActivity.Command 
                { 
                    Id = id, 
                    Activity = activity 
                });

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            await Mediator.Send(new DeleteActivity.Command { Id = id });

            return Ok();
        }
    }
}