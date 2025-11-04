namespace BazarUniversalAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
        public double DiscountPercentage { get; set; }
        public double Rating { get; set; }
        public int Stock { get; set; }
        public string? Brand { get; set; }
        public string? Sku { get; set; }
        public int Weight { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Depth { get; set; }
        public string? WarrantyInformation { get; set; }
        public string? ShippingInformation { get; set; }
        public string? AvailabilityStatus { get; set; }
        public string? ReturnPolicy { get; set; }
        public int MinimumOrderQuantity { get; set; }
        public string? Barcode { get; set; }
        public string? QrCode { get; set; }
        public string? Thumbnail { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
