using AuthSysteamProject.Model;

namespace AuthSysteamProject.DataAccessLayer
{
    public interface IAuthDL
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<SignUpResponse> SignUp(SignUpRequest request);
    }
}
