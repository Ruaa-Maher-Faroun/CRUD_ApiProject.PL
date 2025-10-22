using CRUD_ApiProject.BLL.Services.Interfaces;
using CRUD_ApiProject.DAL.DTO.Requests;
using CRUD_ApiProject.DAL.DTO.Responses;
using CRUD_ApiProject.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Security;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ApiProject.BLL.Services.Classes
{
    public class AuthenticationService : IAuthenticationService
    {
        private IConfiguration _config;
        private UserManager<ApplicationUser> _userManager;
        private IEmailSender _emailSender;

        public AuthenticationService(UserManager<ApplicationUser> userManager, IConfiguration config, IEmailSender emailSender )
        {
            _config = config; 
            _userManager = userManager;
            _emailSender = emailSender;

        }


        public async Task<UserResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user is null)
            {
                throw new Exception("Invalid Email");
            }
            if(!await _userManager.IsEmailConfirmedAsync(user))
            {
                throw new Exception("Please Confirm Your Email");
            }
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
            if (!isPasswordValid) {
                throw new Exception("Invalid email or password");
            }

            return new UserResponse
            {
                Token = await CreateTokenAsync(user)
            };
            }

        public async Task<string> ConfirmEmail(string token, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
            {
                throw new Exception("user not found");
            }

            var res = await _userManager.ConfirmEmailAsync(user,token);
            if (res.Succeeded) {
                return "email confirmed";
            }
            return "email confirmation failed";
        }
        public async Task<UserResponse> RegisterAsync(RegisterRequest registerRequest)
        {
            var user = new ApplicationUser()
            {
                FullName = registerRequest.FullName,
                Email = registerRequest.Email,
                PhoneNumber = registerRequest.PhoneNumber,
                UserName = registerRequest.UserName
             };
            var res = await _userManager.CreateAsync(user, registerRequest.Password);
            if (res.Succeeded) { 
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var escapeToken = Uri.EscapeDataString(token);
                var emailURL = $"https://localhost:7051/api/Identity/Account/ConfirmEmail?token={escapeToken}&userId={user.Id}";
                await _emailSender.SendEmailAsync(user.Email, "Welcome", $"<h1> Hello {user.UserName}</h1><a href='{emailURL}'>Confirm</a>") ;
                return new UserResponse()
                {
                    Token = registerRequest.Email,
                }; 
            }
            else {
                var errors = string.Join("; ", res.Errors.Select(e => e.Description));
                throw new Exception(errors);

            }
            }

        private async Task<string> CreateTokenAsync(ApplicationUser user)
        {

            var Claims = new List<Claim>() {
                new Claim("Email", user.Email),
                new Claim("Name", user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id)
                };
            var Roles = await _userManager.GetRolesAsync(user);
            foreach (var role in Roles) {
                Claims.Add(new Claim("Role", role));
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("jwtOptions")["SecretKey"]));
            var credintials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: Claims,
                expires: DateTime.Now.AddDays(15),
                signingCredentials: credintials

                );
            return new JwtSecurityTokenHandler().WriteToken(token);
             
        }


        public async Task<string> ForgetPassword(ForgotPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) {
                throw new Exception("user not found");
            }
            var random = new Random();
            var code = random.Next(1000,9999).ToString();

            user.CodeResetPassword = code;
            user.PasswordResetCodeExpiry = DateTime.UtcNow.AddMinutes(15);

            await _userManager.UpdateAsync(user);
            await _emailSender.SendEmailAsync(request.Email, "Reset Password", $"<p>Code is {code}</p>" );
            return "check your email";
        }

        public async Task<bool> ResetPassword(ResetPasswordRequest request)
        {

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception("user not found");
            }
            if (user.CodeResetPassword != request.Code) { return false; }
            if (user.PasswordResetCodeExpiry < DateTime.UtcNow) return false;
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var res = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);
            if (res.Succeeded)
            {
                await _emailSender.SendEmailAsync(request.Email, "Change password", "<h1>your password has been changed</h1>");
            }
            return true;

        }

    } 
 }

