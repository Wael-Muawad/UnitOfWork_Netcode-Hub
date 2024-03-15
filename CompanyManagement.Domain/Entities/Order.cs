namespace CompanyManagement.Domain.Entities;

public class Order 
{
    public int Id { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public double Amount { get; set; }

    //Nav
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = new();
}
