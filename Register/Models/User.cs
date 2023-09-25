using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Register.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace Register.Models
{
    public class User
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string password { get; set; }
        public Gender Gender { get; set; }
        
        public string Email { get; set; }
        public string phone { get; set; }
        

    }
}
