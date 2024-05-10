using GraduateThesis.Core.Dtos.CategoryDtos;
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
    public interface ICategoryService : IGenericService<Category,CategoryDto>
    {

        Task<CustomResponseDto<CategoryWithClubsDto>> GetCategoryByIdWithClubsAsync(int id);

        // Overload
        Task<CustomResponseDto<CategoryDto>> AddAsync(CreateCategoryDto dto);

        // Overload
        Task<CustomResponseDto<List<CategoryDto>>> AddRangeAsync(List<CreateCategoryDto> dtos);


        // Overload
        Task<CustomResponseDto<NoDataDto>> UpdateAsync(UpdateCategoryDto dto);


        Task<List<Category>> GetCategoriesByIdsAsync(List<int> ids);
    }
}
