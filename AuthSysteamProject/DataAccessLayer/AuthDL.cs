using AuthSysteamProject.Model;

namespace AuthSysteamProject.DataAccessLayer
{
    public class AuthDL : IAuthDL
    {
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();

            // Hardcoded username and password for testing
            if (request.Username == "admin" && request.Password == "Mayuri@maind07")
            {
                response.IsSuccess = true;
                response.Message = "Login successful";
                response.Token = "test-token-123";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Invalid username or password";
                response.Token = null;
            }

            return response;
        }

        public async Task<SignUpResponse> SignUp(SignUpRequest request)
        {
            return new SignUpResponse
            {
                IsSuccess = false,
                Message = "Signup is not implemented yet."
            };
        }
    }
}
