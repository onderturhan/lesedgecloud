namespace EdgeCloud.LES.ClassLibrary.Core.Models.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; } // should be typed "?" ,because this field shuld be nullable when any record is inserted to database  
    }
}
