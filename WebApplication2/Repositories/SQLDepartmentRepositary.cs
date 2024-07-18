using Microsoft.EntityFrameworkCore;
using WebApplication2.Controllers;
using WebApplication2.Data;
using WebApplication2.Models.Domain;

namespace WebApplication2.Repositories
{
    public class SQLDepartmentRepositary : IDepartmentRepository
    {
        private readonly StudentManagementDbContext dbContext;
        public SQLDepartmentRepositary(StudentManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Department> CreateAsync(Department department)
        {
            await dbContext.Departments.AddAsync(department);
            await dbContext.SaveChangesAsync();
            return department;
        }

        public async Task<List<Department>> GetAllAsync(string? sortBy = null, bool isAscending = true)
        {
            var departmets = dbContext.Departments.Include("Student").AsQueryable();
            if(string.IsNullOrWhiteSpace(sortBy)==false)
            {
                if(sortBy.Equals("DepName", StringComparison.OrdinalIgnoreCase))
                {
                    departmets = isAscending ? departmets.OrderBy(x => x.DepName): departmets.OrderByDescending(x => x.DepName);
                }
            }
            return await dbContext.Departments.Include("Student").ToListAsync();
        }
    }
}
