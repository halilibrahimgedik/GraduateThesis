using AutoMapper;
using GraduateThesis.Core.Dtos.CategoryDtos;
using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Repositories;
using GraduateThesis.Core.Services;
using GraduateThesis.Core.UnitOfWork;
using GraduateThesis.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Services
{
    public class ClubService : GenericService<Club, ClubDto>, IClubService
    {
        private readonly IClubRepository _clubRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ClubService(IGenericRepository<Club> genericRepository, IMapper mapper, IUnitOfWork unitOfWork, IClubRepository clubRepository, ICategoryRepository categoryRepository) : base(genericRepository, mapper, unitOfWork)
        {
            _clubRepository = clubRepository;
            _categoryRepository = categoryRepository;
        }

        // Overload
        public async Task<CustomResponseDto<ClubWitCategoryIdsDto>> AddAsync(CreateClubDto dto)
        {
            var newEntity = _mapper.Map<Club>(dto);

            foreach (var categoryId in dto.Categories)
            {
                var category = await _categoryRepository.GetByIdAsync(categoryId);
                if (category != null)
                {
                    newEntity.ClubCategories.Add(new ClubCategory { CategoryId = category.Id, ClubId = newEntity.Id });
                }
                else
                {
                    // error döndürülecek
                }
            }

            await _clubRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var createdEntity = _mapper.Map<ClubWitCategoryIdsDto>(newEntity);

            return CustomResponseDto<ClubWitCategoryIdsDto>.Success((int)HttpStatusCode.Created, createdEntity);
        }

        // Overload
        public async Task<CustomResponseDto<List<ClubWitCategoryIdsDto>>> AddRangeAsync(IEnumerable<CreateClubDto> dtos)
        {
            var newEntities = new List<Club>();

            foreach (var dto in dtos)
            {
                var newClub = _mapper.Map<Club>(dto);

                foreach (var categoryId in dto.Categories)
                {
                    newClub.ClubCategories.Add(new ClubCategory { CategoryId = categoryId, ClubId = newClub.Id });
                }

                newEntities.Add(newClub);
            }

            await _clubRepository.AddRangeAsync(newEntities);
            await _unitOfWork.CommitAsync();
            var createdEntity = _mapper.Map<List<ClubWitCategoryIdsDto>>(newEntities);

            return CustomResponseDto<List<ClubWitCategoryIdsDto>>.Success((int)HttpStatusCode.Created, createdEntity);
        }

        public async Task<CustomResponseDto<IEnumerable<ClubsWithCategoriesDto>>> GetClubsWithCategoriesAsync()
        {
            var datas = await _clubRepository.GetClubsWithCategoriesAsync();

            var dtos = _mapper.Map<IEnumerable<ClubsWithCategoriesDto>>(datas);

            return CustomResponseDto<IEnumerable<ClubsWithCategoriesDto>>.Success((int)HttpStatusCode.OK, dtos);
        }

        // Overload
        public async Task<CustomResponseDto<NoDataDto>> UpdateAsync(UpdateClubDto dto)
        {
            var entity = await _clubRepository.GetClubByIdWithCategories(dto.Id);

            if(dto.CategoryIds.Count > 0)
            {
                foreach (var categoryId in dto.CategoryIds)
                {
                    if (!entity.ClubCategories.Any(cc => cc.CategoryId == categoryId))
                    {
                        entity.ClubCategories.Add(new ClubCategory { CategoryId = categoryId });
                    }
                }

                var categoriesToRemove = entity.ClubCategories.Where(cc => !dto.CategoryIds.Contains(cc.CategoryId)).ToList();
                foreach (var clubCategory in categoriesToRemove)
                {
                    entity.ClubCategories.Remove(clubCategory);
                }
            }

            _clubRepository.Update(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoDataDto>.Success((int)HttpStatusCode.NoContent);
        }

      
    }

}
