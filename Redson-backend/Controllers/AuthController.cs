using Microsoft.AspNetCore.Mvc;

using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Redson_backend.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Redson_backend.Models;

namespace Redson_backend
{
    public interface IJWTAuthenticationManager
    {

    }

    public class JWTAuthenticationManager: IJWTAuthenticationManager
    {
        public static string tokenKey;

        public JWTAuthenticationManager(string tokenKey)
        {
            JWTAuthenticationManager.tokenKey = tokenKey;
        }
    }

    public class UserCred
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}


namespace Redson_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        public AuthenticateController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }
        public IDataAccessProvider _dataAccessProvider;
        
        [HttpPost]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            try
            {
                if (userCred.Email == null && userCred.Username == null)
                {
                    return BadRequest("Username or Email not found");
                }

                if (userCred.Password == null)
                {
                    return BadRequest("Password not found");
                }
                else
                {
                    userCred.Password = EncodePasswordToBase64(userCred.Password);
                }

                Redson_backend.Models.User userToAuth = null;
                var context = _dataAccessProvider.GetContext();

                if (userCred.Email == null)
                {

                    userToAuth = context.user.Where(u => u.Username == userCred.Username && u.Password == userCred.Password).FirstOrDefault();
                }
                else
                {
                    userToAuth = context.user.Where(u => u.Email == userCred.Email && u.Password == userCred.Password).FirstOrDefault();
                }

                if (userToAuth == null)
                {
                    userToAuth = InsertSuperAdmin();

                    if (userToAuth == null)
                    {
                        return BadRequest("User not found");
                    }
                }

                userToAuth.SessionToken = GetToken();
                context.user.Update(userToAuth);
                context.SaveChanges();
                userToAuth.Password = "";

                return Ok(userToAuth);
            }
            catch (Exception ex)
            {
                Problem(ex.Message);
                throw;
            }

        }

        [HttpGet]
        public IActionResult JustOK() { 
            return Ok("Test Api ok");
        }
            

        protected string GetToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JWTAuthenticationManager.tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        protected Models.User InsertSuperAdmin()
        {
            var context = _dataAccessProvider.GetContext();
            var userList = context.user.ToList();
            if (userList.Count == 0)
            {
                Models.User superAdmin = new Models.User();
                superAdmin.Name = "Redson Super Admin";
                superAdmin.Email = "admin@redson.com";
                superAdmin.Password = EncodePasswordToBase64("redsonadmin");
                superAdmin.Username = "redsonadmin";
                superAdmin.CreatedAt = DateTime.Now;
                superAdmin.UpdatedAt = DateTime.Now;
                superAdmin.IsActive = true;
                superAdmin.IsDeleted = false;

                context.user.Add(superAdmin);
                context.SaveChanges();
                return superAdmin;
            }
            else {
                return null;
            }
        }

        //this function Convert to Encord your Password 
        protected static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        //this function Convert to Decord your Password
        protected string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }
}