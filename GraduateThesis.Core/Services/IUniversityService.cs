using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Dtos.UniversityDtos;
using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Services
{
    public interface IUniversityService : IGenericService<University,UniversityDto>
    {
        // Overload
        Task<CustomResponseDto<UniversityDto>> AddAsync(CreateUniversityDto dto);

        // Overload
        Task<CustomResponseDto<NoDataDto>> UpdateAsync(UpdateUniversityDto dto);
    }
}
