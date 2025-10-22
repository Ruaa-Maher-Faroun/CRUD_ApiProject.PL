using CRUD_ApiProject.BLL.Services.Interfaces;
using CRUD_ApiProject.DAL.DTO.Requests;
using CRUD_ApiProject.DAL.DTO.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ApiProject.PL.Areas.Identity.Controllers
{//www.kashop.com/api/admin
//www.kashop.com/api/customer

    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Identity")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserResponse>> Register(RegisterRequest registerRequest)
        {
            var res = await _authenticationService.RegisterAsync(registerRequest);
            return Ok(res);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserResponse>> Login(LoginRequest loginRequest)
        {
            var res = await _authenticationService.LoginAsync(loginRequest);
            return Ok(res);
        }
        [HttpGet("ConfirmEmail")]

        public async Task<ActionResult<string>> ConfirmEmail([FromQuery] string token, [FromQuery] string userId)
        {
            var result = await _authenticationService.ConfirmEmail(token, userId);
            return Ok(result);
        }


        [HttpPost("forget-password")]

        public async Task<ActionResult<string>> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {

            var result = await _authenticationService.ForgetPassword(request);
            return Ok(result);
        }

        [HttpPatch("reset-password")]

        public async Task<ActionResult<string>> ResetPassword([FromBody] ResetPasswordRequest request)
        {

            var result = await _authenticationService.ResetPassword(request);
            return Ok(result);
        }
    }
}
