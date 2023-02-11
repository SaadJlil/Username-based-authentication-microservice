using System.ComponentModel.DataAnnotations;

namespace MessageNamespace;

public sealed record RegisterMessage 
(
    [Required]
    [StringLength(20, ErrorMessage = "The username must be between 8 and 20 characters long.", MinimumLength = 8)]
    string Username,
    [Required]
    [DataType(DataType.Password)]
    [StringLength(20, ErrorMessage = "The password must be between 8 and 20 characters long.", MinimumLength = 8)]
    string Password
);

public sealed record AuthenticationMessage 
(
    [Required]
    [StringLength(20, ErrorMessage = "The username must be between 8 and 20 characters long.", MinimumLength = 8)]
    string Username,
    [Required]
    [DataType(DataType.Password)]
    [StringLength(20, ErrorMessage = "The password must be between 8 and 20 characters long.", MinimumLength = 8)]
    string Password
);

public sealed record DeleteOwnMessage 
(
    [Required]
    string JwtToken 
);

