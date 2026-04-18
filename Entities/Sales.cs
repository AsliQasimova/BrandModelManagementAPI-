namespace PhoneApp.Entities
{
    public class Sales
    {
        public class Sale
        {
            public int ID { get; set; }
            public int ModelID { get; set; }
            public Model Model { get; set; }
            public decimal SoldPrice { get; set; }
            public DateTime SoldAt { get; set; }
        }
    }
}
