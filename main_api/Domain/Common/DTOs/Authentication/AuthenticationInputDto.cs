using System.ComponentModel.DataAnnotations;

namespace Domain.Common.DTOs.Authentication;


public record AuthenticationInputDto
(
    [Required]
    [StringLength(20, ErrorMessage = "The username must be between 8 and 20 characters long.", MinimumLength = 8)]
    string username,
    [Required]
    [StringLength(20, ErrorMessage = "The password must be between 8 and 20 characters long.", MinimumLength = 8)]
    [DataType(DataType.Password)]
    string password
);