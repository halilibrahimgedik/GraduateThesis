using GraduateThesis.Core.Dtos.AnnouncementDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Repositories;
using GraduateThesis.Core.Services;
using GraduateThesis.Core.UnitOfWork;
using GraduateThesis.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Services
{
    public class AnnouncementService : GenericService<Announcement, AnnouncementDto>, IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IClubRepository _clubRepository;
        private readonly UserManager<AppUser> _userManager;
        public AnnouncementService(IGenericRepository<Announcement> genericRepository, IUnitOfWork unitOfWork, IAnnouncementRepository announcementRepository, IClubRepository clubRepository, UserManager<AppUser> userManager) : base(genericRepository, unitOfWork)
        {
            _announcementRepository = announcementRepository;
            _clubRepository = clubRepository;
            _userManager = userManager;
        }


        public async Task<CustomResponseDto<AnnouncementDto>> AddAsync(CreateAnnouncementDto createAnnouncementDto)
        {
            var clubExist = await _clubRepository.AnyAsync(x=>x.Id == createAnnouncementDto.ClubId);

            if (!clubExist)
            {
                throw new NotFoundException("club not found !");
            }

            var appUserExist = await _userManager.FindByIdAsync(createAnnouncementDto.AppUserId) ?? throw new NotFoundException("user not found !");

            var announcement = ObjectMapper.Mapper.Map<Announcement>(createAnnouncementDto);

            await _announcementRepository.AddAsync(announcement);
            await _unitOfWork.CommitAsync();

            var announcementDto = ObjectMapper.Mapper.Map<AnnouncementDto>(announcement);

            return CustomResponseDto<AnnouncementDto>.Success(StatusCodes.Status201Created, announcementDto);
        }

        public async Task<CustomResponseDto<NoDataDto>> UpdateAsync(UpdateAnnouncementDto updateAnnouncementDto)
        {
            var entityExist = await _announcementRepository.GetByIdAsync(updateAnnouncementDto.Id) ?? throw new NotFoundException("Announcement not found !");

            var user = await _userManager.FindByIdAsync(updateAnnouncementDto.AppUserId) ?? throw new NotFoundException("app user not found !");

            var clubExist = await _clubRepository.AnyAsync(x=>x.Id == updateAnnouncementDto.Id);

            if (!clubExist)
            {
                throw new NotFoundException("club not found !");
            }

            var announcement = ObjectMapper.Mapper.Map<Announcement>(updateAnnouncementDto);

            _announcementRepository.Update(announcement);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoDataDto>.Success(StatusCodes.Status204NoContent);
        } 
    }
}
