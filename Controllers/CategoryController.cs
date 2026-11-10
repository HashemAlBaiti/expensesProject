using expensesProject.Model;
using expensesProject.Serviec.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace expensesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        ICatrgoryServes _catrgoryServes;

        public CategoryController(ICatrgoryServes catrgoryServes)
        {
            _catrgoryServes = catrgoryServes;
            
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Catigory> Catigories = await _catrgoryServes.GetAll();

            return Ok(Catigories);
        }

        [HttpPost("CreateCatgory")]
        public IActionResult Add(Catigory Catigories)
        {
            int? Number = _catrgoryServes.Add(Catigories);

            if (Number is null)
                return BadRequest();


            return Ok(new { Message = "Successful" });

        }

        [HttpPut("EditeCatgor/{Id}")]
        public async Task<IActionResult> Update(int Id, Catigory catigories)
        {
            int? Number = await _catrgoryServes.Update(Id, catigories);

            if (Number is null || Number < 0)
                return NotFound();


            return Ok(new { Message = "Successful" });

        }


        [HttpDelete("DeleteCatgory/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            Catigory catigories = await _catrgoryServes.Delete(Id);

            if (catigories is null)
                return BadRequest();


            return Ok(catigories);

        }
    }
}
