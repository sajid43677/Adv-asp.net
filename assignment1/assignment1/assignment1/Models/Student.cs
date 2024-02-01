using assignment1.Models;
using System;
using System.Collections.Generic;
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
    
        
    public class Student
    {
        // Properties
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string ID { get; set; }
        public Education[] Educations { get; set; }
        

    }
}