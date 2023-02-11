using System.ComponentModel.DataAnnotations;

namespace Domain.Common.DTOs.Controllers.Register;

public sealed record RegisterInputDto
(
    [Required]
    [StringLength(20, ErrorMessage = "The username must be between 8 and 20 characters long.", MinimumLength = 8)]
    string Username,
    [Required]
    [DataType(DataType.Password)]
    [StringLength(20, ErrorMessage = "The password must be between 8 and 20 characters long.", MinimumLength = 8)]
    string Password
);