using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models.Domain;
using WebApplication2.Models.DTO;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly StudentManagementDbContext dbContext;
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(StudentManagementDbContext dbContext, IStudentRepository studentRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        //GETALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var studentsDomain = await studentRepository.GetAllAsync();

            //var studentsDto = new List<StudentDto>();
            //foreach (var studentDomain in studentsDomain)
            //{
            //    studentsDto.Add(new StudentDto()
            //    {
            //        Id = studentDomain.Id,
            //        FirstName = studentDomain.FirstName,
            //        LastName = studentDomain.LastName,
            //        Email = studentDomain.Email,
            //        Contact = studentDomain.Contact,
            //        CreatedOn = studentDomain.CreatedOn,
            //        ModifiedOn = studentDomain.ModifiedOn,
            //    });
            //}
            
            var studentsDto = mapper.Map<List<StudentDto>>(studentsDomain);

            return Ok(studentsDto);
        }

        //GETBYID 
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var studentDomain = await studentRepository.GetByIdAsync(id);

            if (studentDomain == null)
            {
                return NotFound();
            }

            //var studentDto = new StudentDto
            //{
            //    Id = studentDomain.Id,
            //    FirstName = studentDomain.FirstName,
            //    LastName = studentDomain.LastName,
            //    Email = studentDomain.Email,
            //    Contact = studentDomain.Contact,
            //    CreatedOn = studentDomain.CreatedOn,
            //    ModifiedOn = studentDomain.ModifiedOn,
            //};

            var studentDto = mapper.Map<StudentDto> (studentDomain);
            return Ok(studentDto);
        }

        //POST - CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddStudentRequestDto addStudentRequestDto) 
        {
            
            //var studentDomainModel = new Student
            //{
            //    FirstName = addStudentRequestDto.FirstName,
            //    LastName = addStudentRequestDto.LastName,
            //    Email = addStudentRequestDto.Email,
            //    Contact = addStudentRequestDto.Contact,
            //    CreatedOn = addStudentRequestDto.CreatedOn,
            //    ModifiedOn = addStudentRequestDto.ModifiedOn
            //};

            var studentDomainModel = mapper.Map<Student>(addStudentRequestDto);
            studentDomainModel = await studentRepository.CreateAsync(studentDomainModel);

            //var studentDto = new StudentDto
            //{
            //    Id = studentDomainModel.Id,
            //    FirstName = addStudentRequestDto.FirstName,
            //    LastName = addStudentRequestDto.LastName,
            //    Email = addStudentRequestDto.Email,
            //    Contact = addStudentRequestDto.Contact,
            //    CreatedOn = addStudentRequestDto.CreatedOn,
            //    ModifiedOn = addStudentRequestDto.ModifiedOn
            //};

            var studentDto = mapper.Map<StudentDto>(studentDomainModel);
            return CreatedAtAction(nameof(GetById), new {id = studentDto.Id}, studentDto);

        }

        //PUT - UPDATE
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateStudentRequestDto updateStudentRequestDto)
        {
            //var studentDomainModel = new Student
            //{
            //    FirstName = updateStudentRequestDto.FirstName,
            //    LastName = updateStudentRequestDto.LastName,
            //    Email = updateStudentRequestDto.Email,
            //    Contact = updateStudentRequestDto.Contact,
            //    ModifiedOn = updateStudentRequestDto.ModifiedOn,
            //};

            var studentDomainModel = mapper.Map<Student>(updateStudentRequestDto);
            studentDomainModel = await studentRepository.UpdateAsync(id, studentDomainModel);

            if (studentDomainModel == null)
            {
                return NotFound();
            }                        
            await dbContext.SaveChangesAsync();

            //var studentDto = new StudentDto
            //{
            //    Id = studentDomainModel.Id,
            //    FirstName = studentDomainModel.FirstName,
            //    LastName = studentDomainModel.LastName,
            //    Email = studentDomainModel.Email,
            //    Contact = studentDomainModel.Contact,
            //    ModifiedOn = studentDomainModel.ModifiedOn,
            //    DepartmentName = studentDomainModel.DepartmentName;
            //};

            var studentDto = mapper.Map<StudentDto>(studentDomainModel);
            return Ok(studentDto);
        }

        //DELETEBYID - REMOVE
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var studentDomainModel = await studentRepository.DeleteAsync(id);
            if(studentDomainModel == null)
            {
                return NotFound();
            }

            //var studentDto = new StudentDto
            //{
            //    Id = studentDomainModel.Id,
            //    FirstName = studentDomainModel.FirstName,
            //    LastName = studentDomainModel.LastName,
            //    Email = studentDomainModel.Email,
            //    Contact = studentDomainModel.Contact,
            //    CreatedOn = studentDomainModel.CreatedOn,
            //    ModifiedOn = studentDomainModel.ModifiedOn,
            //};

            var studentDto = mapper.Map<StudentDto>(studentDomainModel);
            return Ok(studentDto);
        }
    }
}
