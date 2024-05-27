using GraduateThesis.API.Filters;
using GraduateThesis.Core.Dtos.ApplicationDtos;
using GraduateThesis.Core.Dtos.AppUserDtos;
using GraduateThesis.Core.Dtos.MemberDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateThesis.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/members")]
    public class MembersController : CustomBaseController
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService subscriberService)
        {
            _memberService = subscriberService;
        }



        [ServiceFilter(typeof(ValidateMemberIdFilter))]
        [HttpPost("Clubs")]
        public async Task<IActionResult> GetMemberClubs(MemberIdDto dto)
        {
            return CreateAction(await _memberService.GetMemberClubsAsync(dto.UserId));
        }


        [ServiceFilter(typeof(ValidateMemberIdFilter))]
        [HttpDelete]
        public async Task<IActionResult> DeleteMemberClub(DeleteMemberClubDto dto)
        {
            return CreateAction(await _memberService.DeleteMemberClubAsync(dto));
        }


    }
}
