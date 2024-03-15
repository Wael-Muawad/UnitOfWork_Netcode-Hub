namespace CompanyManagement.Domain.Entities;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;

    //Nav
    public List<Order> Orders { get; set; } = new();
}
