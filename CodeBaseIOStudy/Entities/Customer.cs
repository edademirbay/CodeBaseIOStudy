namespace CodeBaseIOStudy.Entities
{
    public class Customer
    {

        public long Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
     
        public bool IsDelete => false;
      

    }
}

