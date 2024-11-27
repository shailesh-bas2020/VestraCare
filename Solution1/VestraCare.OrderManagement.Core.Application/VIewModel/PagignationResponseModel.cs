namespace VestraCare.OrderManagement.Core.Application.VIewModel
{
    public class PagignationResponseModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public int TotalCount { get; set; }
        public PagignationResponseModel(List<T> items, int count)
        {
            this.Items = items;
            Message = "Successfully get the result";
            TotalCount = count;
            IsSuccess = true;
        }
        public PagignationResponseModel()
        {
            Items = new List<T>();
            Message = "Unable to get the records";
        }
    }
}
