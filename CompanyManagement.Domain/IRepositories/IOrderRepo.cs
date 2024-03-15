using CompanyManagement.Domain.Entities;
using CompanyManagement.Domain.IRepositories.Generics;

namespace CompanyManagement.Domain.IRepositories;

public interface IOrderRepo : IGenericRepo<Order, int>
{
}
