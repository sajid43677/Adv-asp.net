using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace assignment1.Models
{
    public class User
    {
        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "Invalid ID format.")]
        [StringLength(11, ErrorMessage = "ID must be 11 characters long.")]
        public string Id { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z.' -]+$", ErrorMessage = "Only alphabets, dots, hyphens, and spaces are allowed.")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[^\s]{1,10}$", ErrorMessage = "Invalid username format.")]
        public string Username { get; set; }
        [Required]
        [CustomEmailValidation(id: "Id")]
        public string Email { get; set; }
    }

    public class CustomEmailValidationAttribute : ValidationAttribute
    {
        private readonly string id;
        public CustomEmailValidationAttribute(string id)
        {
            this.id = id;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var idInfo = validationContext.ObjectType.GetProperty(id);
            if (idInfo == null)
            {
                return new ValidationResult($"Property {id} not found on {validationContext.ObjectType.Name}.");
            } 
            var currid = idInfo.GetValue(validationContext.ObjectInstance, null)?.ToString();
            if (currid == null)
            {
                return new ValidationResult("ID cannot be null.");
            }
            string[] strings = value.ToString().Split('@');
            if (strings[0] != currid)
            {
                return new ValidationResult("Email and ID do not match.");
            }
            else if (strings[1] != "student.aiub.edu")
            {
                return new ValidationResult("Invalid email domain.");
            }
            return ValidationResult.Success;
            
        }
    }

    


}