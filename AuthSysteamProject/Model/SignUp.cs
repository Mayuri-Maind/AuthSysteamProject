using System.ComponentModel.DataAnnotations;

namespace AuthSysteamProject.Model
{
    public class SignUpRequest
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
}
