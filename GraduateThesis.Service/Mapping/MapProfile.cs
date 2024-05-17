using AutoMapper;
using GraduateThesis.Core.Dtos.AppUserDtos;
using GraduateThesis.Core.Dtos.CategoryDtos;
using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Dtos.UniversityDtos;
using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // AppUser Mapping
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<CreateAppUserDto, AppUser>();


            // Club Mapping
            CreateMap<Club, ClubDto>();
            CreateMap<CreateClubDto, Club>();
            CreateMap<UpdateClubDto, Club>();

            CreateMap<Club, ClubWithCategoriesDto>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.ClubCategories.Select(cc => new CategoryDto()
                {
                    Id = cc.CategoryId,
                    Name = cc.Category.Name,
                    CreatedDate = cc.Category.CreatedDate
                })));

            CreateMap<CreateClubWithImageDto, Club>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary))
               .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));


            // Category Mapping
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            CreateMap<Category, CategoryWithClubsDto>()
                .ForMember(dest => dest.Clubs, opt => opt.MapFrom(src => src.ClubCategories.Select(cc => new ClubDto()
                {
                    Id = cc.ClubId,
                    Name = cc.Club.Name,
                    Summary = cc.Club.Summary,
                    Url = cc.Club.Url,
                    CreatedDate = cc.Club.CreatedDate,
                    IsActive = cc.Club.IsActive
                })));


            // University Mapping
            CreateMap<CreateUniversityDto, University>();
            CreateMap<University, UniversityDto>();
            CreateMap<UpdateUniversityDto, University>();
        }
    }
}
