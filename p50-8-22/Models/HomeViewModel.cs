using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace p50_8_22.Models
{
    public class Role
    {
        public int RoleID { get; set; }

        [Required]
        public string RoleName { get; set; }

        public virtual ICollection<Client> Client { get; set; } = new List<Client>();
    }

    public class Client
    {
        public int UserID { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public int? RoleID { get; set; }

        public DateTime? DateJoined { get; set; }

        public virtual Role Role { get; set; }
    }

    public class HomeViewModel
    {
        public List<Role> Roles { get; set; }
        public List<Client> Clients { get; set; }
    }




    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Login { get; set; }


    }
}
