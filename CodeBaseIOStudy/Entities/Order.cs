namespace CodeBaseIOStudy.Entities
{
    public class Order
    {
       
        public long Id { get; set; }

        public long CustomerId { get; set; }
        public long AddressId { get; set; }

        public long BookId { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }

        //FK prop

        // public virtual ICollection<Customer> Customers { get; set; }
        // public virtual ICollection<Address> Addresses { get; set; }

        // public virtual ICollection<Book> Books { get; set; }
    }
}

