namespace CodeBaseIOStudy.Entities
{
    public class Stock
    {
        public long Id { get; set; }
        public int Amount { get; set; }

        public long BookId { get; set; }

        public virtual ICollection<Book>  Books { get; set; }

    }
}

