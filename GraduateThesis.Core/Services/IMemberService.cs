using GraduateThesis.Core.Dtos.ApplicationDtos;
using GraduateThesis.Core.Dtos.AppUserDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Dtos.MemberDtos;
using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Services
{
    public interface IMemberService
    {
        Task<CustomResponseDto<MemberClubsDto>> GetMemberClubsAsync(string userId);

        Task<bool> AddMemberToClubAsync(string appUserId, int clubId);

        Task<CustomResponseDto<DeleteMemberClubDto>> DeleteMemberClubAsync(DeleteMemberClubDto dto);

    }
}
