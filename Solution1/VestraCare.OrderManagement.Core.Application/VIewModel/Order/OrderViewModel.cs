namespace VestraCare.OrderManagement.Core.Application
{
    public class OrderViewModel
    {
        public int CustomerId { get; set; }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
