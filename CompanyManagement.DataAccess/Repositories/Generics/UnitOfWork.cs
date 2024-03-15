using CompanyManagement.DataAccess.EFContext;
using CompanyManagement.Domain.IRepositories;
using CompanyManagement.Domain.IRepositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.DataAccess.Repositories.Generics;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        EmployeeRepo = new EmployeeRepo(context);
        CustomerRepo = new CustomerRepo(context);
        OrderRepo = new OrderRepo(context);        
    }

    public IEmployeeRepo EmployeeRepo { get; init; }

    public ICustomerRepo CustomerRepo { get; init; }

    public IOrderRepo OrderRepo { get; init; }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveChanges()
    {
        return await _context.SaveChangesAsync();
    }
}
