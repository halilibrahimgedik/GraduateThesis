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
        private readonly IUniversityService _universityService;
        public ClubService(IGenericRepository<Club> genericRepository, IUnitOfWork unitOfWork, IClubRepository clubRepository, ICategoryService categoryService, IFormFileHelper formFileHelper, IUniversityService universityService) : base(genericRepository, unitOfWork)
        {
            _clubRepository = clubRepository;
            _categoryService = categoryService;
            _formFileHelper = formFileHelper;
            _universityService = universityService;
        }


        public async Task<CustomResponseDto<List<ClubDto>>> GetActiveClubsByUniversityAsync(int universityId)
        {
            var clubs = await _clubRepository.GetActiveClubsByUniversityAsync(universityId);
            var clubsDto = ObjectMapper.Mapper.Map<List<ClubDto>>(clubs);

            return CustomResponseDto<List<ClubDto>>.Success(StatusCodes.Status200OK, clubsDto);
        }

        // Overload
        public async Task<CustomResponseDto<ClubWithCategoriesDto>> AddAsync(CreateClubWithImageDto dto)
        {
            var uniExist = await _universityService.AnyAsync(uni => uni.Id == dto.ClubUniversityId);
            if (!uniExist.Data) throw new ClientSideException("University not found !");

            var newEntity = ObjectMapper.Mapper.Map<Club>(dto);

            try
            {
                newEntity.Url = await _formFileHelper.AddAsync(dto.Image);

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
                return CustomResponseDto<ClubWithCategoriesDto>.Fail(StatusCodes.Status400BadRequest, ex.Message);
            }

            var createdEntity = ObjectMapper.Mapper.Map<ClubWithCategoriesDto>(newEntity);

            return CustomResponseDto<ClubWithCategoriesDto>.Success((int)HttpStatusCode.Created, createdEntity);
        }

        public async Task<CustomResponseDto<List<ClubWithCategoriesDto>>> AddRangeAsync(IEnumerable<CreateClubDto> dtos)
        {
            var newEntities = new List<Club>();

            foreach (var dto in dtos)
            {
                var newClub = ObjectMapper.Mapper.Map<Club>(dto);

                var categories = await _categoryService.GetCategoriesByIdsAsync(dto.Categories);

                foreach (var category in categories)
                {
                    newClub.ClubCategories.Add(new ClubCategory { Category = category, ClubId = newClub.Id });
                }

                newEntities.Add(newClub);
            }

            await _clubRepository.AddRangeAsync(newEntities);
            await _unitOfWork.CommitAsync();
            var createdEntity = ObjectMapper.Mapper.Map<List<ClubWithCategoriesDto>>(newEntities);

            return CustomResponseDto<List<ClubWithCategoriesDto>>.Success((int)HttpStatusCode.Created, createdEntity);
        }

        public async Task<CustomResponseDto<List<ClubWithCategoriesDto>>> GetClubsByUniversityWithCategoriesAsync(int universityId)
        {
            var datas = await _clubRepository.GetClubsByUniversityWithCategoriesAsync(universityId);

            var dtos = ObjectMapper.Mapper.Map<List<ClubWithCategoriesDto>>(datas);

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

            if (dto.Image != null)
            {
                var newUrl = await _formFileHelper.UpdateAsync(dto.Image, entity.Url);
                entity.Url = newUrl;
            }

            ObjectMapper.Mapper.Map(dto, entity);

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

        public async Task<CustomResponseDto<NoDataDto>> RemoveWithImageAsync(int id)
        {
            var entity = await _clubRepository.GetByIdAsync(id) ?? throw new ClientSideException("Club not found !");

            _clubRepository.Remove(entity);
            _formFileHelper.Delete(entity.Url);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoDataDto>.Success(StatusCodes.Status204NoContent);
        }

        // OverLoad
        public async Task<CustomResponseDto<ClubWithCategoriesDto>> GetClubByIdWithCategoriesAsync(int id)
        {
            var entity = await _clubRepository.GetClubByIdWithCategories(id);

            var dto = ObjectMapper.Mapper.Map<ClubWithCategoriesDto>(entity);

            return CustomResponseDto<ClubWithCategoriesDto>.Success((int)HttpStatusCode.OK, dto);
        }
    }

}
