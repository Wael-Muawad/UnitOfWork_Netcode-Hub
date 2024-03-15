using CompanyManagement.Domain.Entities;
using CompanyManagement.Domain.IRepositories.Generics;

namespace CompanyManagement.Domain.IRepositories;

public interface ICustomerRepo : IGenericRepo<Customer, int>
{
    Task<List<Customer>> GetCustomersWithOrders();
}
