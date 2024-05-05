using AutoMapper;
using GraduateThesis.Core.Dtos.UniversityDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Repositories;
using GraduateThesis.Core.Services;
using GraduateThesis.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Services
{
    public class UniversityService : GenericService<University, UniversityDto>, IUniversityService
    {
        private readonly IUniversityRepository _universityRepository;
        public UniversityService(IGenericRepository<University> genericRepository, IMapper mapper, IUnitOfWork unitOfWork, IUniversityRepository universityRepository) : base(genericRepository, mapper, unitOfWork)
        {
            _universityRepository = universityRepository;
        }

    }
}
