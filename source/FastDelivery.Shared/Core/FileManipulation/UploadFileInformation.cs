namespace FastDelivery.Shared.Core.FileManipulation
{
    public class UploadFileInformation
    {
        public string FileNameOriginal { get; set; }
        public string FileNameTemp { get; set; }
        public string Extension { get; set; }
        public long Length { get; set; }
        public bool UploadSucess { get; set; }
        public string Path { get; set; }
    }
}