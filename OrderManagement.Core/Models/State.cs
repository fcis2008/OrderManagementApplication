namespace OrderManagement.Core.Models
{
    public class State
    {
        public State()
        {
            Suppliers = new HashSet<Supplier>();
        }

        public int ID { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
