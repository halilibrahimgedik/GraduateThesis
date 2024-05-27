using GraduateThesis.Core.Dtos.ApplicationDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Services
{
    public interface IApplicationService
    {
        Task<CustomResponseDto<NoDataDto>> ApplyForClub(CreateApplicationDto dto);
        Task<CustomResponseDto<List<ApplicationDto>>> GetClubApplicationsByAppUserId(string appUserId);
        Task<CustomResponseDto<NoDataDto>> ManageApplicationById(int applicatinId, bool isApproved);
    }
}
