using GraduateThesis.Core.Services;
using GraduateThesis.Service.Exceptions;

namespace GraduateThesis.API.Utilities.Helpers
{
    public class FormFileHelper : IFormFileHelper
    {
        private readonly IConfiguration _configuration;
        public FormFileHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<string> AddAsync(IFormFile file)
        {
            // dosya uzantısı 2MB'ı aşmamalı
            CheckFileSize(file);

            //dosyanın uzantısını alıyorum.
            string fileExtension = Path.GetExtension(file.FileName);

            DoesUploadAllowed(fileExtension);

            //Guid ile uzantıyı birleştiriyorum.
            //string uniqueFileName = string.Format($"{new Guid()}{fileExtension}");
            string uniqueFileName = GuidHelper_.CreateUniqueFileName() + fileExtension;

            //kaydetmek istediğim yerin tam yolunu alıyorum.
            var imagePath = FilePathToSave.FullPath(uniqueFileName);
            using FileStream fileStream = new(imagePath, FileMode.Create); // FileMode.Create İşletim sisteminin yeni bir dosya oluşturması gerektiğini belirtir. Dosya zaten mevcutsa, üzerine yazılacaktır.

            await file.CopyToAsync(fileStream); // yola kopyalıyorum.
            await fileStream.FlushAsync(); // ara belleği temizliyorum.

            var imageUrl = _configuration.GetSection("WebsiteImageUrl").Value.ToString() + uniqueFileName; // resim url'si

            return await Task.FromResult(imageUrl);
        }

        public void Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            else
            {
                // Dosya zaten silinmiş veya bulunamazsa
                throw new FileNotFoundException("File not found or already deleted.", path);
            }
        }

        public async Task<string> UpdateAsync(IFormFile file, string imageUrl)
        {
            CheckFileSize(file);

            DoesUploadAllowed(Path.GetExtension(file.FileName));

            if (!string.IsNullOrEmpty(imageUrl) && File.Exists(imageUrl))
            {
                using FileStream fileStream = new(imageUrl, FileMode.Create);
                //FileMode.Create burada üzerine yazma işlemi yapar.
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return imageUrl;
            }
            else
            {
                var newUrl = await AddAsync(file);
                return newUrl;
            }
        }



        private void DoesUploadAllowed(string fileExtension)
        {
            var allowedExtensions = new string[] { ".png", ".jpg", ".jpeg" };

            if (!allowedExtensions.Contains(fileExtension))
            {
                throw new ClientSideException($"You cannot upload a file with {fileExtension} extension.");
            }
        }

        private void CheckFileSize(IFormFile file)
        {
            // max dosya boyutu
            const long maxFileSize = 1 * 1024 * 1024; 

            // Dosya boyutunu kontrol edip, max izin verilen boyutu aşarsa hata fırlatacağız
            if (file.Length > maxFileSize)
            {
                throw new ArgumentException($"The file size exceeds the maximum allowed limit of {maxFileSize/(1024*1024)} MB.");
            }
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
        public const string root = "images/";
    }

    public static class FilePathToSave
    {
        public static string FullPath(string path, string root = FileType.root)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), root + path);
        }
    }
}
