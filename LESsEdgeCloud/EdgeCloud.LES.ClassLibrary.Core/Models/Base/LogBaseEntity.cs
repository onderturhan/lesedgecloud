namespace EdgeCloud.LES.ClassLibrary.Core.Models.Base
{
    public abstract class LogBaseEntity
    {
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string MacAddress { get; set; }
        public DateTimeOffset ServerImportDate { get; set; }
    }
}
