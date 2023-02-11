using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class BasedEntity<T> where T: notnull, new()
{
    [Required]
    [Key]
    public T Id { get; set; }
}