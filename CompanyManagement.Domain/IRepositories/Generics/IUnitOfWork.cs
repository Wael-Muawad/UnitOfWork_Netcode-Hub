namespace CompanyManagement.Domain.IRepositories.Generics;

public interface IUnitOfWork : IDisposable
{
    public IEmployeeRepo EmployeeRepo { get; init; }
    public ICustomerRepo CustomerRepo { get; init; }
    public IOrderRepo OrderRepo { get; init; }
    Task<int> SaveChanges();
}
