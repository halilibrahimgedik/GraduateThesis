﻿using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Repositories
{
    public interface IApplicationRepository : IGenericRepository<Application>
    {
        Task ApplyForClub(Application application);

        Task<List<Application>> GetClubApplicationsByClubId(int clubId);
    }
}
