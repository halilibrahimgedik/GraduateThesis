using GraduateThesis.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.API.Utilities.Helpers
{
    public class FormFileHelper : IFormFileHelper
    {
        public string Add(IFormFile file)
        {
            //dosyanın uzantısını alıyorum.
            string fileExtension = Path.GetExtension(file.FileName);

            //Guid ile uzantıyı birleştiriyorum.
            //string uniqueFileName = string.Format($"{new Guid()}{fileExtension}");
            string uniqueFileName = GuidHelper_.CreateUniqueFileName() + fileExtension;

            //kaydetmek istediğim yerin tam yolunu alıyorum.
            var imagePath = FilePathToSave.FullPath(uniqueFileName);
            using FileStream fileStream = new(imagePath, FileMode.Create); // FileMode.Create İşletim sisteminin yeni bir dosya oluşturması gerektiğini belirtir. Dosya zaten mevcutsa, üzerine yazılacaktır.

            file.CopyTo(fileStream); // yola kopyalıyorum.
            fileStream.Flush(); // ara belleği temizliyorum.

            return uniqueFileName;
        }

        public void Delete(string path)
        {
            throw new NotImplementedException();
        }

        public void Update(IFormFile file, string imagePath)
        {
            throw new NotImplementedException();
        }
    }

    public class GuidHelper_
    {
        public static string CreateUniqueFileName()
        {
            return Guid.NewGuid().ToString();
        }
    }

    public static class FileType
    {
        public const string images = "image-";
        public const string root = "images/";
    }

    public static class FilePathToSave
    {
        public static string FullPath(string path, string root = FileType.root, string fileType = FileType.images)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), root + fileType + path);
        }
    }
}
