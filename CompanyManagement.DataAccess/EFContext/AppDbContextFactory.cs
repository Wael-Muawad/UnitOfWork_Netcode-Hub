using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess.EFContext
{
    public class AppDbContextFActory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(
                "Data Source=.;Initial Catalog=UnitOfWorkNetcodeHub;Integrated Security=True;TrustServerCertificate=True"
                );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
