using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using FastDelivery.Shared.Core.FileManipulation.Contracts;

namespace FastDelivery.Shared.Core.FileManipulation.Implementations.Upload
{
    public class UploadFileService : IUploadFileService
    {
        private readonly IFileService _fileService;
        
        public UploadFileService(IFileService fileService)
        {
            _fileService = fileService;
        }
        
        public async Task<UploadFileInformation> UploadFile(IFormFile file, string customerCode,string userName)
        {
            _fileService.CleanTempPath();

            var uploadInfos = new UploadFileInformation()
            {
                Extension = Path.GetExtension(file.FileName),
                Length = file.Length,
            };


            var fileStream = file.OpenReadStream();

            if (fileStream == null || fileStream.Length <= 0)
                throw new BadHttpRequestException("Argument can't null");

            var originalFileName = file.FileName.Trim();

            var originalFileExtension = Path.GetExtension(originalFileName);

            var tempFilePath = _fileService.GetTempFilePathByUserInformation(customerCode,
                userName, originalFileExtension);

            using (var stream = new FileStream(tempFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            uploadInfos.FileNameOriginal = originalFileName;
            uploadInfos.Path = tempFilePath;

            return uploadInfos;
        }

        public async Task<List<UploadFileInformation>> UploadFiles(List<IFormFile> files, string customerCode, string userName)
        {
            var listUpload = new List<UploadFileInformation>();
            
            foreach (var file in files) 
            {
                var response = await UploadFile(file,customerCode,userName);
                listUpload.Add(response);
            }

            return listUpload;
        }
    }
}