namespace WebApplication2.Models.Domain
{
    public class Department
    {
        public Guid Id { get; set; }
        public string DepName { get; set; }
        public string DepHeadName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }

    }
}
