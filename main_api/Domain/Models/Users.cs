using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Domain.Models
{
    public class Users: BaseEntity<Guid>
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Username {get; set;} = null!;
        [Required]
        public int age {get; set;} = 0;
        
    }
}