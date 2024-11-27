namespace VestraCare.OrderManagement.Core.Domain.Entities
{
    public class OrderDetailEntity
    {
        public int CustomerId { get; set; }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; } 
        public decimal TotalAmount { get; set; }
        public int TotalRecords { get; set; }
    }
}
