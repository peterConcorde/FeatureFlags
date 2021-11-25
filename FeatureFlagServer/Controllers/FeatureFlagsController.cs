using FeatureFlagServer.Interfaces;
using FeatureFlagServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeatureFlagServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeatureFlagsController : Controller
    {
        private readonly ILogger<FeatureFlagsController> logger;
        private readonly IFlagService flagService;

        public FeatureFlagsController(ILogger<FeatureFlagsController> logger, IFlagService flagService) : base()
        {
            this.logger = logger;
            this.flagService = flagService;
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetFlag([FromRoute] int id)
        {
            try
            {
                var flag = await flagService.GetFlagAsync(id);

                return flag switch
                {
                    var f when f is not null => Ok(FlagModel.Create(f.Id,f.State)),
                    _ => NotFound()
                };

            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> SetFlag([FromBody] FlagModel flag)
        {
            try
            {
                return await flagService.SetFlagAsync(flag.Id, flag.State) switch
                {
                    var f when f is not null => NoContent(),
                    _ => NotFound()
                };
            } catch
            {
                return StatusCode(500);
            }
        }
    }
}
