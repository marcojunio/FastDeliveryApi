using System;
using Pessoa.Shared.Core.FileManipulation.Contracts;

namespace Pessoa.Shared.Core.FileManipulation.Implementations
{
    public class FileService : IFileService
    {
        public string GetRootPath()
        {
            throw new NotImplementedException();
        }

        public string GetRootTempPath()
        {
            throw new NotImplementedException();
        }

        public string GetTempPath()
        {
            throw new NotImplementedException();
        }

        public string GetTempFileNameByUserInformation(int? customerCode, string userName, string fileExtension = "")
        {
            throw new NotImplementedException();
        }

        public string GetTempFilePathByUserInformation(int? customerCode, string userName, string fileExtension = "")
        {
            throw new NotImplementedException();
        }

        public void CleanTempPath()
        {
            throw new NotImplementedException();
        }

        public void CleanPathsWithDateFmtControl(string rootPath)
        {
            throw new NotImplementedException();
        }

        public void CleanPathsWithDateFmtControl(string rootPath, DateTime limitDate)
        {
            throw new NotImplementedException();
        }
    }
}