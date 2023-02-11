using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;



namespace Infrastructure.Services;


public class Authentication
{
    public static bool VerifyPassword(string password, byte[] PasswordHash, byte[] PasswordSalt)
    {
        var hmac = new HMACSHA512(PasswordSalt);
        return PasswordHash.SequenceEqual(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
    }
    public static void CreatePassword(string password, out byte[] PasswordHash, out byte[] PasswordSalt)
    {
        var hmac = new HMACSHA512();
        PasswordSalt = hmac.Key;
        PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }


    public static string CreateJwtToken(string username, string role, IConfiguration conf)
    {
        RSA rsa = RSA.Create();
        rsa.ImportRSAPrivateKey(
            source:
                Convert.FromBase64String(conf.GetSection("Jwt").GetSection("Private_Key").Value),
            bytesRead: 
                out int _
        );


        var credentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);
        var claims = new[]
        {
            new Claim("username",username),
            new Claim(ClaimTypes.Role, role)
        };
        var token = new JwtSecurityToken(
            conf.GetSection("Jwt").GetSection("Issuer").Value,
            conf.GetSection("Jwt").GetSection("Audience").Value,
            claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }


    

    public static string? GetUsernameFromToken(string token, IConfiguration config)
    {
        try
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
            if (jwtToken == null)
                return null;
            byte[] key = Convert.FromBase64String(config.GetSection("Jwt").GetSection("Public_Key").Value);
            var rsa = RSA.Create();
            rsa.ImportRSAPublicKey(key, out int _);
            TokenValidationParameters parameters = new TokenValidationParameters()
            {
                ValidIssuer = config.GetSection("Jwt").GetSection("Issuer").Value,
                ValidAudience = config.GetSection("Jwt").GetSection("Audience").Value,
                ValidateLifetime = true,
                RequireExpirationTime = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                IssuerSigningKey = new RsaSecurityKey(rsa),
                ClockSkew = TimeSpan.Zero
            };
            SecurityToken securityToken;
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                    parameters, out securityToken);
            return principal.Claims.Where(x => x.Type == "username").First().ToString();
        }
        catch
        {
            Console.WriteLine("Problem a 3chiri");
            return null;
        }
    }
}

//Notes:


//Jwt generator for symmetric auth
/*
public static string CreateJwtToken(string username, string role, IConfiguration conf)
    {
        var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(conf.GetSection("Jwt").GetSection("Key").Value));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim("username",username),
            new Claim(ClaimTypes.Role, role)
        };
        var token = new JwtSecurityToken(
            conf.GetSection("Jwt").GetSection("Issuer").Value,
            conf.GetSection("Jwt").GetSection("Audience").Value,
            claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
*/



//Get Username Claim from jwt token