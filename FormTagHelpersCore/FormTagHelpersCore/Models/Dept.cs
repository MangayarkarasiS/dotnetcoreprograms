using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//https://jonhilton.net/aspnet-core-forms-cheat-sheet/#checkbox 

namespace FormTagHelpersCore.Models
{
    public enum Dept
    {
        None,
        IT,
        HR,
        Admin
    }
    public class Gendercls
    {
        public int Id { get; set; }
        public string Gendnm { get; set; }

    }
   
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Incorrect name Format")]
        
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Incorrect Email Format")]
        [RegularExpression(@"^[A-Z]{1}[a-z0-9._%+-]+@[a-z0-9.-]+\.(com|in)$")]             
        public string Email { get; set; }
        [Required(ErrorMessage = "Please choose gender")]
        public string  Gender { get; set; }        
        public Dept Department { get; set; }

        public IEnumerable<Gendercls> gens { get; set; }
        public int selectnm { get; set; }

        public bool AcceptsTerms { get; set; }
        
        [StringLength(255)]
        public string Bio { get; set; }

    }
}
