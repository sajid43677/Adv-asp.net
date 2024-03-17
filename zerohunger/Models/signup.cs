using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Text;
using zerohunger.EF;

namespace zerohunger.Models
{
    public class signup
    {
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [CustomEmailValidation]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must contain at least one uppercase, one lowercase, one number and one special character")]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        public string Location { get; set; }
        public string msg { get; set; }

    }

    public class CustomEmailValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var db = new ZeroHungerEntities(); 

            string email = value as string;

            if (string.IsNullOrEmpty(email))
            {
                return ValidationResult.Success;
            }

            bool isEmailExists = db.users.Any(u => u.email == email);

            if (isEmailExists)
            {
                return new ValidationResult("Email already exists.");
            }
            return ValidationResult.Success;
        }
    }
}