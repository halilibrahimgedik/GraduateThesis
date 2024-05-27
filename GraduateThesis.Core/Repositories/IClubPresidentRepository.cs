using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Repositories
{
    public interface IClubPresidentRepository : IGenericRepository<ClubPresident>
    {

        Task<List<Club>> GetClubsOfPresident(string appUserId);
    }
}
