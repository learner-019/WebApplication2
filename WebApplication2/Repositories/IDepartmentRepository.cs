using WebApplication2.Models.Domain;

namespace WebApplication2.Repositories
{
    public interface IDepartmentRepository
    {
       Task<Department> CreateAsync(Department department);
       Task<List<Department>> GetAllAsync(string? sortBy = null,bool isAscending = true);

    }
}
