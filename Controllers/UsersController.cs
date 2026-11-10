using expensesProject.Model;
using expensesProject.Serviec.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace expensesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserServiec _userServiec;
        public UsersController(IUserServiec userServiec)
        {
             _userServiec =  userServiec; ;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<User> Users=await _userServiec.GetAll();

            return Ok(Users);
        }

        [HttpPost("CreateUser")]
        public  IActionResult Add(User Users)
        {
            int? Number=_userServiec.Add(Users);

            if (Number is null)
                return BadRequest();


            return Ok(new { Message = "Successful" });

        }

        [HttpPut("EditeUser/{Id}")]
        public async Task<IActionResult> Update(int Id,User Users)
        {
            int? Number = await _userServiec.Update(Id,Users);

            if (Number is null || Number < 0)
                return NotFound();


            return Ok(new { Message = "Successful" });

        }


        [HttpDelete("DeleteUser/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            User Users = await _userServiec.Delete(Id);

            if (Users is null)
                return BadRequest();


            return Ok(Users);

        }







    }
}
