using System.Runtime.InteropServices;
using WebApplication2.Models.Domain;

namespace WebApplication2.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(Guid id);
        Task<Student> CreateAsync(Student student);
        Task<Student?> UpdateAsync(Guid id, Student student);
        Task<Student?> DeleteAsync(Guid id);
    }
}
