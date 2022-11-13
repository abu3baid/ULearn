using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using ULearn.Core.Manager.Interfaces;
using ULearn.ModelView.ModelView;

namespace ULearn.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class UserController : ApiBaseController
    {
        private IUserManager _userManager;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger,
                              IUserManager userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        // GET: api/<UserController>
        [HttpGet]
        [Route("api/v{version:apiVersion}/user/ahmad")]
        [MapToApiVersion("1")]
        public IActionResult Get()
        {            
            return Ok();
        }

        [Route("api/v{version:apiVersion}/user/signUp")]
        [HttpPost]
        [AllowAnonymous]
        [MapToApiVersion("1")]
        public IActionResult SignUp([FromBody] UserRegistrationModel userReg)
        {
            var res = _userManager.SignUp(userReg);
            return Ok(res);
        }

        [Route("api/v{version:apiVersion}/user/login")]
        [HttpPost]
        [AllowAnonymous]
        [MapToApiVersion("1")]
        public IActionResult Login([FromBody] LoginModelView userReg)
        {
            var res = _userManager.Login(userReg);
            return Ok(res);
        }

        [Route("api/v{version:apiVersion}/user/fileretrive/profilepic")]
        [HttpGet]
        [MapToApiVersion("1")]
        public IActionResult Retrive(string filename)
        {
            var folderPath = Directory.GetCurrentDirectory();
            folderPath = $@"{folderPath}\{filename}";
            var byteArray = System.IO.File.ReadAllBytes(folderPath);
            return File(byteArray, "image/jpeg", filename);
        }

        // PUT api/<UserController>/5
        // update my profile
        [Route("api/v{version:apiVersion}/user/me")]
        [HttpPut]
        [MapToApiVersion("1")]
        [Authorize]
        public IActionResult UpdateMyProfile(UserModel request)
        {
            var user = _userManager.UpdateProfile(LoggedInUser , request);
            return Ok(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete]
        [Route("api/v{version:apiVersion}/user/{id}")]
        [MapToApiVersion("1")]
        public IActionResult Delete(int id)
        {
            _userManager.DeleteUser(LoggedInUser, id);
            return Ok();
        }


        [Route("api/v{version:apiVersion}/user/Confirmation")]
        [HttpPost]
        [MapToApiVersion("1")]
        public IActionResult Confirmation(string confirmationLink)
        {
            var result = _userManager.Confirmation(confirmationLink);
            return Ok(result);
        }
    }
}
