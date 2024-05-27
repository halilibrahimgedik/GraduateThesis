using GraduateThesis.Core.Dtos.AnnouncementDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Repositories;
using GraduateThesis.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Services
{
    public class AnnouncementService : GenericService<Announcement, AnnouncementDto>
    {
        public AnnouncementService(IGenericRepository<Announcement> genericRepository, IUnitOfWork unitOfWork) : base(genericRepository, unitOfWork)
        {
        }


    }
}
