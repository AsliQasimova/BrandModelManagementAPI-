namespace PhoneApp.Entities
{
    public class StockMovement
    {
        public int ID { get; set; }
        public int ModelID { get; set; }
        public Model Model { get; set; }
        public int QuantityChanged { get; set; }
        public string MovementType { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}
