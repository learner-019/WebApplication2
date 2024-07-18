using WebApplication2.Models.Domain;

namespace WebApplication2.Models.DTO
{
    public class DepartmentDto
    {
        public string DepName { get; set; }
        public string DepHeadName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public StudentDto Student { get; set; }

    }
}
