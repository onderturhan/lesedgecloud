using System.ComponentModel.DataAnnotations.Schema;

namespace EdgeCloud.LES.API.TestDatabase.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [ForeignKey("CompanyId")]
        public ICollection<User>? Users { get; set; }
    }
}
