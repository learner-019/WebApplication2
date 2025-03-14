﻿using WebApplication2.Models.Domain;

namespace WebApplication2.Models.DTO
{
    public class UpdateStudentRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public string DepartmentName { get; set; }


    }
}
