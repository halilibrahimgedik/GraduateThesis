using GraduateThesis.Core.Dtos;
using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Dtos.SubscriberDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Repositories;
using GraduateThesis.Core.Services;
using GraduateThesis.Core.UnitOfWork;
using GraduateThesis.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IClubRepository _clubRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SubscriberService(ISubscriberRepository subscriberRepository, IUnitOfWork unitOfWork, IClubRepository clubRepository)
        {
            _subscriberRepository = subscriberRepository;
            _unitOfWork = unitOfWork;
            _clubRepository = clubRepository;
        }


        public async Task<CustomResponseDto<SubscriberClubsDto>> GetSubscriberClubsAsync(string id)
        {
            var clupAppUserList = await _subscriberRepository.GetSubscriberClubs(id).ToListAsync();

            if (!clupAppUserList.Any()) return CustomResponseDto<SubscriberClubsDto>.Success(StatusCodes.Status200OK);

            var clubsOfSubscriber = new SubscriberClubsDto { UserId = id };

            foreach (var item in clupAppUserList)
            {
                clubsOfSubscriber.SubscribersClubs.Add(ObjectMapper.Mapper.Map<SubsClubsDto>(item));
            }

            return CustomResponseDto<SubscriberClubsDto>.Success(StatusCodes.Status200OK, clubsOfSubscriber);
        }

        public async Task<CustomResponseDto<CreateSubscriberDto>> AddSubscriberToClubAsync(CreateSubscriberDto dto)
        {
            var clubAppUser = ObjectMapper.Mapper.Map<ClubAppUser>(dto);

            await _subscriberRepository.AddAsync(clubAppUser);
            await _unitOfWork.CommitAsync();

            var responseDto = ObjectMapper.Mapper.Map<CreateSubscriberDto>(clubAppUser);

            return CustomResponseDto<CreateSubscriberDto>.Success(StatusCodes.Status201Created, responseDto);

        }

        public async Task<CustomResponseDto<DeleteSubscriberClubDto>> DeleteSubscriberClubAsync(DeleteSubscriberClubDto dto)
        {
            var appUser = await _subscriberRepository.GetClubAppUserById(dto.UserId) ?? throw new NotFoundException(" User not found !");

            var doesClubExist = await _clubRepository.AnyAsync(club => club.Id == dto.ClubId);

            if (!doesClubExist)
            {
                throw new NotFoundException($"club not found ! - id: {dto.ClubId}");
            }

            _subscriberRepository.Remove(appUser.AppUserId,appUser.ClubId);
            _unitOfWork.Commit();

            return CustomResponseDto<DeleteSubscriberClubDto>.Success(StatusCodes.Status204NoContent);
        }


    }
}
