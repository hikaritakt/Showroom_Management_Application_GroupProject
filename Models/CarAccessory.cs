namespace ShowroomApp.Models
{
    internal class CarAccessory
    {
        public int CarAccessoryId { get; set; }
        public int CarId { get; set; }
        public int AccessoryId { get; set; }
        public int Quantity { get; set; }

        public Car? Car { get; set; }
        public Accessory? Accessory { get; set; }
    }
}