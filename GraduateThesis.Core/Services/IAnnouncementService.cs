using GraduateThesis.Core.Dtos.AnnouncementDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Services
{
    public interface IAnnouncementService : IGenericService<Announcement,AnnouncementDto>
    {
        Task<CustomResponseDto<AnnouncementDto>> AddAsync(CreateAnnouncementDto createAnnouncementDto);

        Task<CustomResponseDto<NoDataDto>> UpdateAsync(UpdateAnnouncementDto updateAnnouncementDto);
    }
}
