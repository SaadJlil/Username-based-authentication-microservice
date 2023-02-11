using System.ComponentModel.DataAnnotations;


namespace Domain.Common.DTOs.Register;


public record RegisterInputDto
(
    [Required]
    [StringLength(15, ErrorMessage = "Name must be between 5 and 20 characters long.", MinimumLength = 8)]
    string Name, 
    [Required]
    [StringLength(20, ErrorMessage = "The username must be between 8 and 20 characters long.", MinimumLength = 8)]
    string username,
    [Required]
    [StringLength(20, ErrorMessage = "The password must be between 8 and 20 characters long.", MinimumLength = 8)]
    [DataType(DataType.Password)]
    string password,
    [Required]
    [Range(13, 100, ErrorMessage = "Age must be between 13 and 100")]
    int age 
);