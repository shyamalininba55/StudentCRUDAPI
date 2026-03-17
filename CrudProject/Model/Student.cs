using System.ComponentModel.DataAnnotations;

namespace CrudProject.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; } 
        public string? Name { get; set; }   
        public string? Address { get; set; } 
        public string PhoneNo { get; set; }    
    }
}
