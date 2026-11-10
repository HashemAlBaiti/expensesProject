using expensesProject.Model;
using expensesProject.Serviec;
using expensesProject.Serviec.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace expensesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        IPaymentMethodServiec _paymentMethodServiec;
        public PaymentMethodController(IPaymentMethodServiec paymentMethodServiec)
        {
            _paymentMethodServiec = paymentMethodServiec;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<PaymentMethod> Payment = await _paymentMethodServiec.GetAll();

            return Ok(Payment);
        }

        [HttpPost("CreatePaymentMethod")]
        public IActionResult Add(PaymentMethod Payment)
        {
            int? Number = _paymentMethodServiec.Add(Payment);

            if (Number is null)
                return BadRequest();


            return Ok(new { Message = "Successful" });

        }

        [HttpPut("EditeCatgor/{Id}")]
        public async Task<IActionResult> Update(int Id, PaymentMethod Payment)
        {
            int? Number = await _paymentMethodServiec.Update(Id, Payment);

            if (Number is null || Number < 0)
                return NotFound();


            return Ok(new { Message = "Successful" });

        }


        [HttpDelete("DeleteCatgory/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            PaymentMethod payment = await _paymentMethodServiec.Delete(Id);

            if (payment is null)
                return BadRequest();


            return Ok(payment);

        }

    }
}
