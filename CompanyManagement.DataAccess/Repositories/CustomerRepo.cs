using CompanyManagement.DataAccess.EFContext;
using CompanyManagement.DataAccess.Repositories.Generics;
using CompanyManagement.Domain.Entities;
using CompanyManagement.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.DataAccess.Repositories;

public class CustomerRepo : GenericRepo<Customer, int>, ICustomerRepo
{
    private readonly AppDbContext _context;

    public CustomerRepo(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetCustomersWithOrders()
    {
        return await _context.Customers.Include(x => x.Orders).ToListAsync();
    }
}
