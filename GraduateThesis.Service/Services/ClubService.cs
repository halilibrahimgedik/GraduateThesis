using AutoMapper;
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
    public class ClubService : GenericService<Club,ClubDto>, IClubService
    {
        private readonly IClubRepository _clubRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ClubService(IGenericRepository<Club> genericRepository, IMapper mapper, IUnitOfWork unitOfWork, IClubRepository clubRepository, ICategoryRepository categoryRepository) : base(genericRepository, mapper, unitOfWork)
        {
            _clubRepository = clubRepository;
            _categoryRepository = categoryRepository;
        }

        // Overload
        public async Task<CustomResponseDto<ClubWithCategoryDto>> AddAsync(CreateClubDto dto)
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

            var createdEntity = _mapper.Map<ClubWithCategoryDto>(newEntity);

            return CustomResponseDto<ClubWithCategoryDto>.Success((int)HttpStatusCode.Created, createdEntity);
        }
    }
}
