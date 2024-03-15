using CompanyManagement.DataAccess.EFContext;
using CompanyManagement.DataAccess.Repositories.Generics;
using CompanyManagement.Domain.Entities;
using CompanyManagement.Domain.IRepositories;

namespace CompanyManagement.DataAccess.Repositories;

public class EmployeeRepo : GenericRepo<Employee, int>, IEmployeeRepo
{
    public EmployeeRepo(AppDbContext context) : base(context)
    {
    }
}
