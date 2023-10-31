namespace CodeBaseIOStudy.Entities
{
    public class Book
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        //FK
        public virtual Stock Stock { get; set; }
     
    }
}
