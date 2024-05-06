using AutoMapper;
using GraduateThesis.Core.Dtos.CategoryDtos;
using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Repositories;
using GraduateThesis.Core.Services;
using GraduateThesis.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Services
{
    public class CategoryService : GenericService<Category, CategoryDto>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IGenericRepository<Category> genericRepository, IMapper mapper, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository) : base(genericRepository, mapper, unitOfWork)
        {
            _categoryRepository = categoryRepository;
        }


        // Overload
        public async Task<CustomResponseDto<CategoryDto>> AddAsync(CreateCategoryDto dto)
        {
            var newEntity = _mapper.Map<Category>(dto);
            await _categoryRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var categoryDto = _mapper.Map<CategoryDto>(newEntity);

            return CustomResponseDto<CategoryDto>.Success((int)HttpStatusCode.OK, categoryDto);
        }

    }
}
