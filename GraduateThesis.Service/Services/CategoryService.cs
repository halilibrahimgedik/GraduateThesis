using AutoMapper;
using GraduateThesis.Core.Dtos.CategoryDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Repositories;
using GraduateThesis.Core.Services;
using GraduateThesis.Core.UnitOfWork;
using GraduateThesis.Service.Exceptions;
using System.Net;

namespace GraduateThesis.Service.Services
{
    public class CategoryService : GenericService<Category, CategoryDto>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IGenericRepository<Category> genericRepository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository) : base(genericRepository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task<CustomResponseDto<CategoryWithClubsDto>> GetCategoryByIdWithClubsAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdWithClubsAsync(id);

            var categoryWithClubsDto = ObjectMapper.Mapper.Map<CategoryWithClubsDto>(category);

            return CustomResponseDto<CategoryWithClubsDto>.Success((int)HttpStatusCode.OK, categoryWithClubsDto);
        }

        // Overload
        public async Task<CustomResponseDto<CategoryDto>> AddAsync(CreateCategoryDto dto)
        {
            var newEntity = ObjectMapper.Mapper.Map<Category>(dto);
            await _categoryRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var categoryDto = ObjectMapper.Mapper.Map<CategoryDto>(newEntity);

            return CustomResponseDto<CategoryDto>.Success((int)HttpStatusCode.Created, categoryDto);
        }

        // Overload
        public async Task<CustomResponseDto<NoDataDto>> UpdateAsync(UpdateCategoryDto dto)
        {
            var doesExist = await _categoryRepository.AnyAsync(c=>c.Id == dto.Id);

            if (!doesExist)
            {
                throw new ClientSideException($"there is no Category with id: {dto.Id}"); 
            }

            var entity = ObjectMapper.Mapper.Map<Category>(dto);
            _categoryRepository.Update(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoDataDto>.Success((int)HttpStatusCode.NoContent);
        }

        // Overload
        public async Task<CustomResponseDto<List<CategoryDto>>> AddRangeAsync(List<CreateCategoryDto> dtos)
        {
            var newEntities = ObjectMapper.Mapper.Map<List<Category>>(dtos);

            await _categoryRepository.AddRangeAsync(newEntities);
            await _unitOfWork.CommitAsync();

            var datas = ObjectMapper.Mapper.Map<List<CategoryDto>>(newEntities);

            return CustomResponseDto<List<CategoryDto>>.Success((int)HttpStatusCode.Created, datas);
        }

        public async Task<List<Category>> GetCategoriesByIdsAsync(List<int> ids)
        {
            return await _categoryRepository.GetCategoriesByIdsAsync(ids);
        }
    }
}
