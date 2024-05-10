using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Services
{
    public interface IClubService : IGenericService<Club, ClubDto>
    {
        Task<CustomResponseDto<List<ClubDto>>> GetAllActiveClubsAsync();
        Task<CustomResponseDto<List<ClubWithCategoriesDto>>> GetClubsWithCategoriesAsync();

        Task<CustomResponseDto<ClubWithCategoriesDto>> AddAsync(CreateClubWithImageDto dto);

        Task<CustomResponseDto<List<ClubWithCategoriesDto>>> AddRangeAsync(IEnumerable<CreateClubDto> dtos);

        Task<CustomResponseDto<NoDataDto>> UpdateAsync(UpdateClubDto dto);
    }
}
