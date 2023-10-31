namespace CodeBaseIOStudy.Entities
{
    public class Address
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string City { get; set; }

        public string Town { get; set; }

        public string AdressDetail { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
