namespace ContosoPizza.Models
{
    /*
     * This class represents the many-to-many relationship between Order and Detail. 
     */
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}