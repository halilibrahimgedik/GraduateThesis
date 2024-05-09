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
        string Add(IFormFile file);
        void Delete(string path);
        void Update(IFormFile file, string imagePath);
    }
}
