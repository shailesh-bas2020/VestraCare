namespace VestraCare.OrderManagement.Core.Application.Models
{
    public class OrderFilter:BaseFilter
    {
        public int? CustomerId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
