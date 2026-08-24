using System.ComponentModel.DataAnnotations;

namespace AuthSysteamProject.Model
{
    public class SignUpRequest1
    {
        [Required]
        public string Username {get; set;}
        [Required]
        public string Password {get; set;}
        [Required]
        public string ConfirmPassword { get; set;}
        [Required]
        public string Role { get; set;}

    }
    public class SignUpResponse
    {
        public bool IsSuccess {  get; set;}
        public string Message { get; set;}
    }
        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class LoginResponse
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
            public string Token { get; set; }
        }
    public class SignUpRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }



}
