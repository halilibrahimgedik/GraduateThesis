using AutoMapper;
using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Repositories;
using GraduateThesis.Core.Services;
using GraduateThesis.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Services
{
    public class ClubService : GenericService<Club,ClubDto>, IClubService
    {
        private readonly IClubRepository _clubRepository;
        public ClubService(IGenericRepository<Club> genericRepository, IMapper mapper, IUnitOfWork unitOfWork, IClubRepository clubRepository) : base(genericRepository, mapper, unitOfWork)
        {
            _clubRepository = clubRepository;
        }


    }
}
