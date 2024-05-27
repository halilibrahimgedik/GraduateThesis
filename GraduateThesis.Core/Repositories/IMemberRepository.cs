using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Repositories
{
    public interface IMemberRepository : IGenericRepository<ClubAppUser>
    {
        IQueryable<ClubAppUser> GetMemberClubs(string id);
        Task<ClubAppUser> GetClubAppUserById(string id);

        Task<bool> isUserMemberOfSpecifiedClub(string userId, int clubId);

        void Remove(string userId, int clubId);
    }
}
