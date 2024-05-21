using GraduateThesis.API.Filters;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateThesis.API.Controllers
{
    [Route("api/subs")]
    public class SubscribersController : CustomBaseController
    {
        private readonly ISubscriberService _subscriberService;

        public SubscribersController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        [ServiceFilter(typeof(SubscriberNotFoundFilter))]
        [HttpGet]
        public async Task<IActionResult> GetSubscriberClubs(string userId)
        {
            return CreateAction(await _subscriberService.GetSubscriberClubsAsync(userId));
        }
    }
}
