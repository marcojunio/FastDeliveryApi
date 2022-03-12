using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Pessoa.Shared.Core.FileManipulation.Contracts;

namespace Pessoa.Shared.Core.FileManipulation.Implementations.Upload
{
    public class UploadFileService : IUploadFileService
    {
        private readonly IFileService _fileService;
        
        public UploadFileService(IFileService fileService)
        {
            _fileService = fileService;
        }
        
        public async Task<UploadFileInformation> UploadFile(IFormFile file)
        {
            var uploadInfos = new UploadFileInformation()
            {
                Extension = Path.GetExtension(file.FileName),
                Length = file.Length,
                FileNameOriginal = file.FileName,
            };


            return uploadInfos;
        }

        public async Task<List<UploadFileInformation>> UploadFiles(List<IFormFile> files)
        {
            var listUpload = new List<UploadFileInformation>();
            
            foreach (var file in files) 
            {
                var response = await UploadFile(file);
                listUpload.Add(response);
            }

            return listUpload;
        }
    }
}