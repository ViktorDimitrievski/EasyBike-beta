namespace Domain.Models
{
    public class File
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public string Link { get; set; }
        
        public virtual FileType FileType { get; set; }
        public int FileTypeID { get; set; }
    }
}