using System.ComponentModel.DataAnnotations;
namespace Models;
    public class RegisterModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters")]
        public string Username { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }

        public RegisterModel(String Email,String Username, String Password){
            this.Email=Email;
            this.Username=Username;
            this.Password=Password;
        }
    }