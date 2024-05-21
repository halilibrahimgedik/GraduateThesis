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
        Task<CustomResponseDto<List<ClubDto>>> GetActiveClubsByUniversityAsync(int universityId);
        Task<CustomResponseDto<List<ClubWithCategoriesDto>>> GetClubsByUniversityWithCategoriesAsync(int universityId);

        Task<CustomResponseDto<ClubWithCategoriesDto>> AddAsync(CreateClubWithImageDto dto);

        Task<CustomResponseDto<List<ClubWithCategoriesDto>>> AddRangeAsync(IEnumerable<CreateClubDto> dtos);

        Task<CustomResponseDto<NoDataDto>> UpdateAsync(UpdateClubDto dto);

        Task<CustomResponseDto<NoDataDto>> RemoveWithImageAsync(int id);

        Task<CustomResponseDto<ClubWithCategoriesDto>> GetClubByIdWithCategoriesAsync(int id);
    }
}
