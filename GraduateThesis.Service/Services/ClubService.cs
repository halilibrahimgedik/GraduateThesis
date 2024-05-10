using AutoMapper;
using GraduateThesis.Core.Dtos.CategoryDtos;
using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Repositories;
using GraduateThesis.Core.Services;
using GraduateThesis.Core.UnitOfWork;
using GraduateThesis.Repository.Repositories;
using GraduateThesis.Service.Exceptions;
using Microsoft.AspNetCore.Http;
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
        private readonly ICategoryService _categoryService;
        private readonly IFormFileHelper _formFileHelper;
        public ClubService(IGenericRepository<Club> genericRepository, IMapper mapper, IUnitOfWork unitOfWork, IClubRepository clubRepository, ICategoryService categoryService, IFormFileHelper formFileHelper) : base(genericRepository, mapper, unitOfWork)
        {
            _clubRepository = clubRepository;
            _categoryService = categoryService;
            _formFileHelper = formFileHelper;
        }


        public async Task<CustomResponseDto<List<ClubDto>>> GetAllActiveClubsAsync()
        {
            var clubs= await _clubRepository.GetAllActiveClubsAsync();
            var activeClubs = _mapper.Map<List<ClubDto>>(clubs);
            return CustomResponseDto<List<ClubDto>>.Success(StatusCodes.Status200OK, activeClubs);
        }

        // Overload
        public async Task<CustomResponseDto<ClubWithCategoriesDto>> AddAsync(CreateClubWithImageDto dto)
        {
            var newEntity = _mapper.Map<Club>(dto);

            try
            {
                newEntity.Url = await _formFileHelper.Add(dto.Image);

                var categories = await _categoryService.GetCategoriesByIdsAsync(dto.Categories);

                foreach (var category in categories)
                {
                    newEntity.ClubCategories.Add(new ClubCategory() { Category = category, CategoryId = newEntity.Id });
                }

                await _clubRepository.AddAsync(newEntity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                return CustomResponseDto<ClubWithCategoriesDto>.Fail(StatusCodes.Status400BadRequest,ex.Message);
            }

            var createdEntity = _mapper.Map<ClubWithCategoriesDto>(newEntity);

            return CustomResponseDto<ClubWithCategoriesDto>.Success((int)HttpStatusCode.Created, createdEntity);
        }

        public async Task<CustomResponseDto<List<ClubWithCategoriesDto>>> AddRangeAsync(IEnumerable<CreateClubDto> dtos)
        {
            var newEntities = new List<Club>();

            foreach (var dto in dtos)
            {
                var newClub = _mapper.Map<Club>(dto);

                var categories = await _categoryService.GetCategoriesByIdsAsync(dto.Categories);

                foreach (var category in categories)
                {
                    newClub.ClubCategories.Add(new ClubCategory { Category = category, ClubId = newClub.Id });
                }

                newEntities.Add(newClub);
            }

            await _clubRepository.AddRangeAsync(newEntities);
            await _unitOfWork.CommitAsync();
            var createdEntity = _mapper.Map<List<ClubWithCategoriesDto>>(newEntities);

            return CustomResponseDto<List<ClubWithCategoriesDto>>.Success((int)HttpStatusCode.Created, createdEntity);
        }

        public async Task<CustomResponseDto<List<ClubWithCategoriesDto>>> GetClubsWithCategoriesAsync()
        {
            var datas = await _clubRepository.GetClubsWithCategoriesAsync();

            var dtos = _mapper.Map<List<ClubWithCategoriesDto>>(datas);

            return CustomResponseDto<List<ClubWithCategoriesDto>>.Success((int)HttpStatusCode.OK, dtos);
        }

        // Overload
        public async Task<CustomResponseDto<NoDataDto>> UpdateAsync(UpdateClubDto dto)
        { 
            var entity = await _clubRepository.GetClubByIdWithCategories(dto.Id);

            if (entity == null)
            {
                throw new ClientSideException($"Bad Request, there is no any Club with  id : {dto.Id}");
            }

            _mapper.Map(dto, entity);

            entity.Url = await _formFileHelper.Add(dto.Image);

            foreach (var categoryId in dto.Categories)
            {
                if (!entity.ClubCategories.Any(cc => cc.CategoryId == categoryId))
                {
                    entity.ClubCategories.Add(new ClubCategory { CategoryId = categoryId, ClubId = entity.Id });
                }
            }

            var categoriesToRemove = entity.ClubCategories.Where(cc => !dto.Categories.Contains(cc.CategoryId)).ToList();
            foreach (var clubCategory in categoriesToRemove)
            {
                entity.ClubCategories.Remove(clubCategory);
            }
            
            _clubRepository.Update(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoDataDto>.Success((int)HttpStatusCode.NoContent);
        }
    }

}
