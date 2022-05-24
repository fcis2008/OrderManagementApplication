namespace OrderManagement.API.Resources
{
    public class SupplierResource
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public string AddressLine1 { get; set; } = null!;
        public string AddressLine2 { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public int FKStateID { get; set; }
        public string? StateName { get; set; }
        public bool IsActive { get; set; }
    }
}
