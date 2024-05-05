using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Services
{
    public interface IClubService : IGenericService<Club,ClubDto>
    {
        Task<CustomResponseDto<ClubWithCategoryDto>> AddAsync(CreateClubDto dto);
    }
}
