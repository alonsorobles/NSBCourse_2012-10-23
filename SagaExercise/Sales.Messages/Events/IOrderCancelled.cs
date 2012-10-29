namespace Sales.Messages.Events
{
    public interface IOrderCancelled
    {
        int OrderId { get; set; } 
    }
}