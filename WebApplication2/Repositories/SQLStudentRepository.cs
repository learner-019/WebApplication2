using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebApplication2.Data;
using WebApplication2.Models.Domain;

namespace WebApplication2.Repositories
{
    public class SQLStudentRepositary : IStudentRepository
    {
        private readonly StudentManagementDbContext dbContext;

        public SQLStudentRepositary(StudentManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Student> CreateAsync(Student student)
        {
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student?> DeleteAsync(Guid id)
        {
            var existingRegion = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;                
            }
            dbContext.Students.Remove(existingRegion);
            await dbContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await dbContext.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Student> UpdateAsync(Guid id, Student student)
        {
            var existingStudent = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if(existingStudent == null)
            {
                return null;
            }
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Email = student.Email;
            existingStudent.Contact = student.Contact;
            existingStudent.ModifiedOn = student.ModifiedOn;
            existingStudent.DepartmentName = student.DepartmentName;


            await dbContext.SaveChangesAsync();
            return existingStudent;
        }
    }
}
