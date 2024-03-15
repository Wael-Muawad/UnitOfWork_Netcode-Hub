using CompanyManagement.Domain.Entities;
using CompanyManagement.Domain.IRepositories.Generics;

namespace CompanyManagement.Domain.IRepositories;

public interface IEmployeeRepo : IGenericRepo<Employee, int>
{
}
