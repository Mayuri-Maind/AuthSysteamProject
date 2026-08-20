using AuthSysteamProject.DataAccessLayer;
using AuthSysteamProject.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthSysteamProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthDL _authDL;
        public AuthController(IAuthDL authDL)
        {
            _authDL = authDL;
        }

        public async Task<IActionResult> SignUp(SignUpRequest singUpRequest)  //for status ok
        {
            SignUpResponse response = new SignUpResponse();
            try
            {

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
