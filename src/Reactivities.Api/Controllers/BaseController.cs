using Microsoft.AspNetCore.Mvc;

namespace Reactivities.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
        }

        #region [ActionResult] sync

        protected ActionResult Result<TData>(TData data) where TData : class
        {
            return new JsonResult(
                new
                {
                    Success = true,
                    Data = data
                });
        }

        protected ActionResult Result()
        {
            return new JsonResult(
                new
                {
                    Success = true,
                    Data = "Success!"
                });
        }

        #endregion [IActionResult] async
        
    }
}