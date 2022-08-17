namespace EdgeCloud.LES.API.TestDatabase.Model
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
                
        public int CompanyId { get; set; }
        public Company? Company { get; set; }

        public int AddressId { get; set; }
        public Address? Address { get; set; }

    }
}
