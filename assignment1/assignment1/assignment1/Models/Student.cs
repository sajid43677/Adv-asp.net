using assignment1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace assignment1.Models
{
    public class Education
    {
        // Properties
        public string Degree { get; set; }
        public string Institution { get; set; }
        public string Result { get; set; }
        public string PassingYear { get; set; }
    }

    public class References
    {
        public string Name { get; set; }
        public string Email { get; set; }
        
    }

    public class Project
    {
        public string Name { get; set; }
        public string Course { get; set; }

    }


    public class Student
    {
        // Properties
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public string PresentAddress { get; set; }
        public string DateOfBirth { get; set; }
        public string ID { get; set; }
        public Education[] Educations { get; set; }
        public References[] References { get; set; }
        public Project[] Projects { get; set; }
        

    }
}