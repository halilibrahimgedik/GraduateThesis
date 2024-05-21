using GraduateThesis.Core.Dtos.AppUserDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Dtos.SubscriberDtos;
using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Services
{
    public interface ISubscriberService
    {
        Task<CustomResponseDto<SubscriberClubsDto>> GetSubscriberClubsAsync(string userId);

        Task<CustomResponseDto<CreateSubscriberDto>> AddSubscriberToClubAsync(CreateSubscriberDto dto);
    }
}
