using CompanyManagement.Domain.Entities;
using CompanyManagement.Domain.IRepositories.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.OrderRepo.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Order order)
        {
            if (order is null)
                return BadRequest();

            var customer = await _unitOfWork.CustomerRepo.GetById(order.CustomerId);
            if (customer is null)
                return BadRequest("customer is not exist");

            order.Customer = customer;
            await _unitOfWork.OrderRepo.Add(order);

            int result = await _unitOfWork.SaveChanges();
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> FindByName(string name)
        {
            var result = await _unitOfWork.OrderRepo.Find(c => c.ItemName.Contains(name));
            return result is null ? BadRequest() : Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            var result = await _unitOfWork.OrderRepo.GetById(id);
            return result is null ? BadRequest() : Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Order order)
        {
            if (order is null)
                return BadRequest();
            _unitOfWork.OrderRepo.Update(order);

            int result = await _unitOfWork.SaveChanges();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Order order)
        {
            if (order is null)
                return BadRequest();
            _unitOfWork.OrderRepo.Delete(order);

            int result = await _unitOfWork.SaveChanges();
            return Ok(result);
        }
    }
}
