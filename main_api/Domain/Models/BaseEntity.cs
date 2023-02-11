using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class BaseEntity<T> where T : notnull, new()
    {

        [Required]
    	public Guid id { get; set; }

    }
}
