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
    public interface IClubService : IGenericService<Club, ClubDto>
    {
        Task<CustomResponseDto<IEnumerable<ClubsWithCategoriesDto>>> GetClubsWithCategoriesAsync();

        Task<CustomResponseDto<ClubWitCategoryIdsDto>> AddAsync(CreateClubDto dto);

        Task<CustomResponseDto<List<ClubWitCategoryIdsDto>>> AddRangeAsync(IEnumerable<CreateClubDto> dtos);

        Task<CustomResponseDto<NoDataDto>> UpdateAsync(UpdateClubDto dto);
    }
}
