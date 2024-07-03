namespace Backend.Model;

public class Order
{
    public int Id { get; set; }
    public int OriginNodeId { get; set; }
    public int TargetNodeId { get; set; }
    public int Load { get; set; }
    public decimal Value { get; set; }
    public DateTime DeliveryDateUtc { get; set; }
    public DateTime ExpirationDateUtc { get; set; }
}