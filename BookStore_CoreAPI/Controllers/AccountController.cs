using BookStore_CoreAPI.Model;
using BookStore_CoreAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore_CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository) 
        {
            this._accountRepository = accountRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUp signup)
        {
            var result=await _accountRepository.SignUP(signup);
            if(result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized ();
        }


        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] SignIn signIn)
        {
            var result = await _accountRepository.LogIn(signIn);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
            
        }

    }
}
