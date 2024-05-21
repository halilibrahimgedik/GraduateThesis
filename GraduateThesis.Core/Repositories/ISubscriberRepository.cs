﻿using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Repositories
{
    public interface ISubscriberRepository : IGenericRepository<ClubAppUser>
    {
        IQueryable<ClubAppUser> GetSubscriberClubs(string id);
    }
}
