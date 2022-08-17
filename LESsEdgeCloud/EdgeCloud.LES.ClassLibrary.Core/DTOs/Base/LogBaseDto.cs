namespace EdgeCloud.LES.ClassLibrary.Core.DTOs.Base
{
    public abstract class LogBaseDto
    {
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string MacAddress { get; set; }
        public DateTimeOffset ServerImportDate { get; set; }
    }
}
