using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Dtos.SubscriberDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Repositories;
using GraduateThesis.Core.Services;
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
        private readonly UserManager<AppUser> _userManager;

        public SubscriberService(UserManager<AppUser> userManager, ISubscriberRepository subscriberRepository)
        {
            _userManager = userManager;
            _subscriberRepository = subscriberRepository;
        }


        public async Task<CustomResponseDto<SubscriberClubsDto>> GetSubscriberClubsAsync(string id)
        {
            var clupAppUserList = await _subscriberRepository.GetSubscriberClubs(id).ToListAsync();

            if(!clupAppUserList.Any()) return CustomResponseDto<SubscriberClubsDto>.Success(StatusCodes.Status200OK);

            var clubsOfSubscriber = new SubscriberClubsDto { UserId = id };

            foreach (var item in clupAppUserList)
            {
                clubsOfSubscriber.SubscribersClubs.Add(ObjectMapper.Mapper.Map<SubsClubsDto>(item));
            }

            return CustomResponseDto<SubscriberClubsDto>.Success(StatusCodes.Status200OK, clubsOfSubscriber);
        }
    }
}
