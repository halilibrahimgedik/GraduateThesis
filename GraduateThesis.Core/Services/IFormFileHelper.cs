using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Services
{
    public interface IFormFileHelper
    {
        Task<string> AddAsync(IFormFile file);
        void Delete(string path);
        Task<string> UpdateAsync(IFormFile file, string imagePath);
    }
}
