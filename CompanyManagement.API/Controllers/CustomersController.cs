using CompanyManagement.Domain.Entities;
using CompanyManagement.Domain.IRepositories.Generics;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.CustomerRepo.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer customer)
        {
            if (customer is null)
                return BadRequest();
            await _unitOfWork.CustomerRepo.Add(customer);

            int result = await _unitOfWork.SaveChanges();
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> FindByName(string name)
        {
            var result = await _unitOfWork.CustomerRepo.Find(c => c.Name.Contains(name));
            return result is null ? BadRequest() : Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            var result = await _unitOfWork.CustomerRepo.GetById(id);
            return result is null ? BadRequest() : Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Customer customer)
        {
            if (customer is null)
                return BadRequest();
            _unitOfWork.CustomerRepo.Update(customer);

            int result = await _unitOfWork.SaveChanges();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Customer customer)
        {
            if (customer is null)
                return BadRequest();
            _unitOfWork.CustomerRepo.Delete(customer);

            int result = await _unitOfWork.SaveChanges();
            return Ok(result);
        }


        // The following Action Methods are coming from Customized interface, they are not part of the general generic repo.
        [HttpGet]
        public async Task<IActionResult> GetCustomersWithOrders()
        {
            var result = await _unitOfWork.CustomerRepo.GetCustomersWithOrders();
            return Ok(result);
        }
    }
}
