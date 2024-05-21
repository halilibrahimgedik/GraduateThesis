using GraduateThesis.API.Filters;
using GraduateThesis.Core.Dtos.SubscriberDtos;
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



        [ServiceFilter(typeof(ValidateSubscriberIdFilter))]
        [HttpPost("GetSubscriberClubs")]
        public async Task<IActionResult> GetSubscriberClubs(SubscriberIdDto dto)
        {
            return CreateAction(await _subscriberService.GetSubscriberClubsAsync(dto.UserId));
        }

        [ServiceFilter(typeof(ValidateSubscriberIdFilter))]
        [HttpPost]
        public async Task<IActionResult> AddSubscriberToClub(CreateSubscriberDto dto)
        {
            return CreateAction(await _subscriberService.AddSubscriberToClubAsync(dto));
        }

        [ServiceFilter(typeof(ValidateSubscriberIdFilter))]
        [HttpDelete]
        public async Task<IActionResult> DeleteSubscriberClub(DeleteSubscriberClubDto dto)
        {
            return CreateAction(await _subscriberService.DeleteSubscriberClubAsync(dto));
        }
    }
}
