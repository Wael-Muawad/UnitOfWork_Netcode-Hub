using CompanyManagement.DataAccess.EFContext;
using CompanyManagement.DataAccess.Repositories.Generics;
using CompanyManagement.Domain.Entities;
using CompanyManagement.Domain.IRepositories;

namespace CompanyManagement.DataAccess.Repositories;

public class OrderRepo : GenericRepo<Order, int>, IOrderRepo
{
    public OrderRepo(AppDbContext context) : base(context)
    {
    }
}
