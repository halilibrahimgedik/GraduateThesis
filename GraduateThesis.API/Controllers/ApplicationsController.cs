using GraduateThesis.API.Filters;
using GraduateThesis.Core.Dtos.ApplicationDtos;
using GraduateThesis.Core.Dtos.MemberDtos;
using GraduateThesis.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateThesis.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin,club-president")]
    [Route("api/applications")]
    public class ApplicationsController : CustomBaseController
    {
        private readonly IApplicationService _applicationService;
        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> ApplyForClub([FromForm] CreateApplicationDto dto)
        {
            return CreateAction(await _applicationService.ApplyForClub(dto));
        }

        [ServiceFilter(typeof(ValidateMemberIdFilter))]
        [HttpPost("show")]
        public async Task<IActionResult> GetClubApplications(MemberIdDto dto)
        {
            return CreateAction(await _applicationService.GetClubApplicationsByAppUserId(dto.UserId));
        }


        [HttpGet("manage/{applicationId}/isApproved")]
        public async Task<IActionResult> ManageApplication(int applicationId, bool isApproved)
        {
            return CreateAction(await _applicationService.ManageApplicationById(applicationId, isApproved));
        }
    }
}
