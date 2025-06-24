using CRMSystem.BLL.DTOs;
using CRMSystem.BLL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRMSystem.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("api/auth/register")]
        public IHttpActionResult Register([FromBody] RegisterRequestDTO registerRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _userService.Register(registerRequest);
                return Ok("Registration successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("api/auth/login")]
        public IHttpActionResult Login([FromBody] LoginRequestDTO request)
        {
            var user = _userService.Authenticate(request.Email, request.Password);

            if (user == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Invalid email or password.");
            }

            var response = new
            {
                message = "Login successful.",
                user = user
            };

            return Ok(response);
        }

    }
}
