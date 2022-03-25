using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FastDelivery.Shared.Core.FileManipulation.Contracts
{
    public interface IUploadFileService
    {
        /// <summary>
        /// Make upload from single file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<UploadFileInformation> UploadFile(IFormFile file, string customerCode, string userName);
        
        /// <summary>
        /// Make upload from many files
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        Task<List<UploadFileInformation>> UploadFiles(List<IFormFile> files, string customerCode, string userName);
    }
}