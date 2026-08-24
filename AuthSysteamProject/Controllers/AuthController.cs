using AuthSysteamProject.DataAccessLayer;
using AuthSysteamProject.Model;
//using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace AuthSysteamProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthDL _authDL;

        public AuthController(IAuthDL authDL)
        {
            _authDL = authDL;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            LoginResponse response = new LoginResponse();

            try
            {
                response = await _authDL.Login(loginRequest);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpRequest signUpRequest)
        {
            SignUpResponse response = new SignUpResponse();

            try
            {
                response = await _authDL.SignUp(signUpRequest);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}
