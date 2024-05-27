using GraduateThesis.Core.Dtos.ApplicationDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Repositories;
using GraduateThesis.Core.Services;
using GraduateThesis.Core.UnitOfWork;
using GraduateThesis.Repository.Repositories;
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
    public class ApplicationService :IApplicationService
    {
        private readonly IApplicationRepository _repository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IClubPresidentRepository _clubPresidentRepository;
        private readonly IMemberService _memberService;
        private readonly IFormFileHelper _formFileHelper;
        private readonly IUnitOfWork _unitOfWork;


        public ApplicationService(IApplicationRepository repository, IUnitOfWork unitOfWork, UserManager<AppUser> userManager, IClubPresidentRepository clubPresidentRepository, IMemberService memberService, IFormFileHelper formFileHelper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _clubPresidentRepository = clubPresidentRepository;
            _memberService = memberService;
            _formFileHelper = formFileHelper;
        }


        public async Task<CustomResponseDto<NoDataDto>> ApplyForClub(CreateApplicationDto dto)
        {
            var pdfUrl = await _formFileHelper.AddCvAsync(dto.CvFile);

            var application = ObjectMapper.Mapper.Map<Application>(dto);

            application.Cv = pdfUrl;


            await _repository.ApplyForClub(application);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoDataDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponseDto<List<ApplicationDto>>> GetClubApplicationsByAppUserId(string appUserId)
        {
            if (string.IsNullOrEmpty(appUserId)) throw new ClientSideException("AppUserId can not be empty");
            var doesUserExist = await _userManager.FindByIdAsync(appUserId) ?? throw new NotFoundException("AppUser not found !");

            // kullanıcı yetki kontrolü
            var roles = await _userManager.GetRolesAsync(doesUserExist);
            if (!isAppuserAuthorized(roles.ToList())) throw new ForbiddenException("the user has no authorized role for this operation");

            var clubsOfPresident = await _clubPresidentRepository.GetClubsOfPresident(appUserId);

            if (clubsOfPresident == null || clubsOfPresident.Count <= 0)
            {
                return CustomResponseDto<List<ApplicationDto>>.Success(StatusCodes.Status200OK);
            }

            var applicationList = new List<Application>();

            foreach (var club in clubsOfPresident)
            {
                applicationList.AddRange(await _repository.GetClubApplicationsByClubId(club.Id));
            }

            var applicationDtos = ObjectMapper.Mapper.Map<List<ApplicationDto>>(applicationList);

            return CustomResponseDto<List<ApplicationDto>>.Success(StatusCodes.Status200OK, applicationDtos);
        }

        public async Task<CustomResponseDto<NoDataDto>> ManageApplicationById(int applicatinId, bool isApproved)
        {
            var application = await _repository.GetByIdAsync(applicatinId) ?? throw new NotFoundException("application not found");

            application.isApproved = isApproved;

            if (application.isApproved)
            {
                var isAdded = await _memberService.AddMemberToClubAsync(application.AppUserId, application.ClubId);

                if (isAdded) return CustomResponseDto<NoDataDto>.Success(StatusCodes.Status200OK);

                throw new Exception($"something went wrong while approving {application.AppUserId} application, pls contact your system admin");
            }
            else
            {
                _repository.Remove(application);
                _unitOfWork.Commit();
                return CustomResponseDto<NoDataDto>.Success(StatusCodes.Status200OK);
            }
        }


        

        private bool isAppuserAuthorized(List<string> roles)
        {
            return roles.Contains("admin") || roles.Contains("club-president");
        }
    }
}
