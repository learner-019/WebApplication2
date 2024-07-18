using Microsoft.EntityFrameworkCore;
using WebApplication2.Models.Domain;

namespace WebApplication2.Data
{
    public class StudentManagementDbContext: DbContext
    {
        public StudentManagementDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
                        
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

            //Seed Data for Department
            //CSE,MECHANICAL

            //var departments = new List<Department>()
            //{ 
            //    new Department()
            //    {
            //        Id=Guid.Parse("19f82588-8112-43d5-85c6-af15aeea8a56"),
            //        DepName="CSE",
            //        DepHeadName="Head of CSE",
            //        CreatedOn = DateTime.Now,
            //        ModifiedOn = DateTime.Now
            //    },
            //    new Department()
            //    {
            //        Id=Guid.Parse("461fcb83-52df-45a3-823c-d514b32ec87c"),
            //        DepName="Mechanical",
            //        DepHeadName="Head of Mechanical",
            //        CreatedOn = DateTime.Now,
            //        ModifiedOn = DateTime.Now
            //    }
            //};

            ////seed department to the database
            //modelBuilder.Entity<Department>().HasData(departments);

       // }
    }
}
