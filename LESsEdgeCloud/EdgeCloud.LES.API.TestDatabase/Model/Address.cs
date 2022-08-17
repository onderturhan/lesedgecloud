using System.ComponentModel.DataAnnotations.Schema;

namespace EdgeCloud.LES.API.TestDatabase.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [ForeignKey("AddressId")]
        public ICollection<User>? Users { get; set; }
    }
}
