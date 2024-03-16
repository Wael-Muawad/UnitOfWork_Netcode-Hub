using CompanyManagement.DataAccess.Repositories.Generics;
using CompanyManagement.Domain.Entities;
using CompanyManagement.Domain.IRepositories.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.EmployeeRepo.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee employee)
        {
            if (employee is null)
                return BadRequest();
            await _unitOfWork.EmployeeRepo.Add(employee);

            int result = await _unitOfWork.SaveChanges();
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> FindByName(string name)
        {
            var result = await _unitOfWork.EmployeeRepo.Find(c => c.Name.Contains(name));
            return result is null ? BadRequest() : Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            var result = await _unitOfWork.EmployeeRepo.GetById(id);
            return result is null ? BadRequest() : Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Employee employee)
        {
            if (employee is null)
                return BadRequest();
             _unitOfWork.EmployeeRepo.Update(employee);

            int result = await _unitOfWork.SaveChanges();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Employee employee)
        {
            if (employee is null)
                return BadRequest();
            _unitOfWork.EmployeeRepo.Delete(employee);

            int result = await _unitOfWork.SaveChanges();
            return Ok(result);
        }

    }
}
