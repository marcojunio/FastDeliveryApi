using System;

namespace Pessoa.Shared.Core.FileManipulation.Contracts
{
    public interface IFileService
    {
        /// <summary>
        /// Retorna a pasta base para manipulações de arquivos
        /// </summary>
        /// <returns></returns>
        string GetRootPath();

        /// <summary>
        /// Return path temp
        /// </summary>
        /// <returns></returns>
        string GetRootTempPath();

        /// <summary>
        /// Retorna uma pasta temporária
        /// </summary>
        /// <returns></returns>
        string GetTempPath();

        /// <summary>
        /// Cria um nome de arquivo temporário baseado no usuário e na extensão do arquivo
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="userName"></param>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        string GetTempFileNameByUserInformation(string customerCode, string userName, string fileExtension = "");

        /// <summary>
        /// Cria um path para um arquivo temporário baseado no usuário e na extensão do arquivo
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="userName"></param>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        string GetTempFilePathByUserInformation(string customerCode, string userName, string fileExtension = "");

        /// <summary>
        /// Limpa a pasta temporária
        /// </summary>
        void CleanTempPath();

        /// <summary>
        /// Limpa as pastas temporárias antigas
        /// </summary>
        void CleanPathsWithDateFmtControl(string rootPath);

        /// <summary>
        /// Limpa as pastas temporárias antigas
        /// </summary>
        void CleanPathsWithDateFmtControl(string rootPath, DateTime limitDate);


        /// <summary>
        /// Create path for client
        /// </summary>
        /// <param name="path"></param>
        string CratePathForClient(string path);
    }
}