using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models.Domain;
using WebApplication2.Models.DTO;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentsController(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            this.mapper = mapper;
            this.departmentRepository = departmentRepository;
        }


        //CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddDepartmentRequestDto addDepartmentRequestDto)
        {
            var departmentDomainModel = mapper.Map<Department>(addDepartmentRequestDto);
            await departmentRepository.CreateAsync(departmentDomainModel);

            return Ok(mapper.Map<DepartmentDto>(departmentDomainModel));

        }

        //GETALL
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? sortBy, [FromQuery] bool? isAscending)
        {
            var departmentsDomainModel = await departmentRepository.GetAllAsync(sortBy, isAscending ?? true);
            return Ok(mapper.Map<List<DepartmentDto>>(departmentsDomainModel));
        }

    }
}
