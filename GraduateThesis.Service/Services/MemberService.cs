using GraduateThesis.Core.Dtos;
using GraduateThesis.Core.Dtos.ApplicationDtos;
using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Dtos.MemberDtos;
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
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IClubRepository _clubRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MemberService(IMemberRepository memberRepository, IUnitOfWork unitOfWork, IClubRepository clubRepository)
        {
            _memberRepository = memberRepository;
            _unitOfWork = unitOfWork;
            _clubRepository = clubRepository;
        }


        public async Task<CustomResponseDto<MemberClubsDto>> GetMemberClubsAsync(string id)
        {
            var clupAppUserList = await _memberRepository.GetMemberClubs(id).ToListAsync();

            if (!clupAppUserList.Any()) return CustomResponseDto<MemberClubsDto>.Success(StatusCodes.Status200OK);

            var clubsOfSubscriber = new MemberClubsDto { UserId = id };

            foreach (var item in clupAppUserList)
            {
                clubsOfSubscriber.MemberClubs.Add(ObjectMapper.Mapper.Map<MemberClubDto>(item));
            }

            return CustomResponseDto<MemberClubsDto>.Success(StatusCodes.Status200OK, clubsOfSubscriber);
        }

        public async Task<bool> AddMemberToClubAsync(string appUserId, int clubId)
        {
            // Does Club Exist ??
            var doesClubExist = await _clubRepository.AnyAsync(club => club.Id == clubId);
            if (!doesClubExist) throw new NotFoundException($"Club not found. club-id :{clubId}");

            //  Does the user member of specified club ??
            var doesExistClubAppUser = await _memberRepository.isUserMemberOfSpecifiedClub(appUserId, clubId);
            if (doesExistClubAppUser)
            {
                throw new ClientSideException("User already a member of specified club.");
            }

            var newClubAppUser = new ClubAppUser()
            {
                AppUserId = appUserId,
                ClubId = clubId,
            };
            await _memberRepository.AddAsync(newClubAppUser);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<CustomResponseDto<DeleteMemberClubDto>> DeleteMemberClubAsync(DeleteMemberClubDto dto)
        {
            var appUser = await _memberRepository.GetClubAppUserById(dto.UserId) ?? throw new NotFoundException(" User not a member of any club!");

            var doesClubExist = await _clubRepository.AnyAsync(club => club.Id == dto.ClubId);

            if (!doesClubExist)
            {
                throw new NotFoundException($"club not found ! - id: {dto.ClubId}");
            }

            var memberOf = await _memberRepository.isUserMemberOfSpecifiedClub(dto.UserId, dto.ClubId);

            if (!memberOf)
            {
                throw new ClientSideException($"The user is not a member of the club you are trying to delete.");
            }

            _memberRepository.Remove(appUser.AppUserId, appUser.ClubId);
            _unitOfWork.Commit();

            return CustomResponseDto<DeleteMemberClubDto>.Success(StatusCodes.Status204NoContent);
        }

    }
}
