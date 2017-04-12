
using System.ComponentModel.DataAnnotations;

namespace project312.Models
{
    public class Subscriber
    {
        public int Id {get; set;}

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email {get; set;}

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name {get; set;}       
    }
}