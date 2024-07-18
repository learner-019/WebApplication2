namespace WebApplication2.Models.DTO
{
    public class AddDepartmentRequestDto
    {
        public string DepName { get; set; }
        public string DepHeadName { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public Guid StudentId { get; set; }
    }
}
