using expensesProject.DTOs;
using expensesProject.Model;
using expensesProject.Server.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace expensesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        IExpensesServers _expensesServers;
        public ExpensesController(IExpensesServers expensesServers)
        {
            _expensesServers = expensesServers;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ExpensesRequstDtos?> Expenseies = await _expensesServers.GetAll();

            return Ok(Expenseies);
        }

        [HttpGet("GetAllByUserName/{Name}")]
        public async Task<IActionResult> GetAllByUserName(string Name)
        {
            IEnumerable<ExpensesRequstDtos?> Expenseies = await _expensesServers.GetByUserName(Name);

            return Ok(Expenseies);
        }

        [HttpGet("GetAllByUserId/{Id}")]
        public async Task<IActionResult> GetAllByUserId(int Id)
        {
            IEnumerable<ExpensesRequstDtos?> Expenseies = await _expensesServers.GetByUserId(Id);

            return Ok(Expenseies);
        }

        [HttpGet("GetAllByCatgoryId/{Id}")]
        public async Task<IActionResult> GetAllByCatgoryId(int Id)
        {
            IEnumerable<ExpensesRequstDtos?> Expenseies = await _expensesServers.GetByCategoryId(Id);

            return Ok(Expenseies);
        }

        [HttpGet("GetAllByPaymentMethidId/{Id}")]
        public async Task<IActionResult> GetAllByPaymentMethidId(int Id)
        {
            IEnumerable<ExpensesRequstDtos?> Expenseies = await _expensesServers.GetByPaymentMethodId(Id);

            return Ok(Expenseies);
        }


        [HttpPost("CreateExpenses")]
        public async Task<IActionResult> Add(Expenses? expenses)
        {
            int? Number = _expensesServers.Add(expenses);

            if (Number is null)
                return BadRequest();


            return Ok(new { Message = "Successful" });


        }

        [HttpPut("EditExpenses/{Id}")]
        public async Task<IActionResult> Update(int Id, Expenses? expenses)
        {
            int? Number = await _expensesServers.Update(Id,expenses);

            if (Number is null || Number < 0)
                return BadRequest();


            return Ok(new { Message = "Successful" });

        }


        [HttpDelete("Deletexpenses")]
        public async Task<IActionResult> Delete(int Id)
        {
            Expenses Expenseies = await _expensesServers.Delete(Id);

            if (Expenseies is null)
                return NotFound();


            return Ok(new { Message = "Successful" });


        }

    }
}
