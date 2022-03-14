using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Pessoa.Shared.Core.FileManipulation.Contracts;
using Pessoa.Shared.Helpers;

namespace Pessoa.Shared.Core.FileManipulation.Implementations
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        public string GetRootPath()
        {
            var path = _webHostEnvironment.WebRootPath ??
                Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot");

            return path;
        }

        public string GetRootTempPath()
        {
            var path = Path.Combine(GetRootPath(), "Temp");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }

        public string GetTempPath()
        {
            var dt = DateTime.Now.ToString("yyyyMMdd");
            var path = Path.Combine(GetRootTempPath(), dt);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }

        public string GetTempFileNameByUserInformation(string customerCode, string userName, string fileExtension = "")
        {
            throw new NotImplementedException();
        }

        public string GetTempFilePathByUserInformation(string customerCode, string userName, string fileExtension = "")
        {
            if (String.IsNullOrEmpty(fileExtension))
                fileExtension = ".tmp";

            var code = customerCode?.ToString() ?? "";
            var user = StringHelper.MakeAlphaNumeric(userName, new[] { '_', '-' }) ?? "usr";

            return $"{code}_{user}_{Guid.NewGuid().ToString()}{fileExtension}";
        }

        public void CleanTempPath()
        {
            CleanPathsWithDateFmtControl(GetTempPath());
        }

        public void CleanPathsWithDateFmtControl(string rootPath)
        {
            CleanPathsWithDateFmtControl(rootPath, DateTime.Now.AddDays(-2));
        }

        public void CleanPathsWithDateFmtControl(string rootPath, DateTime limitDate)
        {
            try
            {
                var limitDatePathFormat = limitDate.ToString("yyyyMMdd");
                var directories = Directory.GetDirectories(rootPath);

                foreach (var directory in directories)
                {
                    var directoryName = new DirectoryInfo(directory).Name;

                    if (String.CompareOrdinal(directoryName, limitDatePathFormat) <= 0)
                        Directory.Delete(directory, true);
                }
            }
            catch
            {
                //Ignored
            }
        }
    }
}