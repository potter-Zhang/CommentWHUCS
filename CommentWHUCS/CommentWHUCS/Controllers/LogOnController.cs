using CommentWHUCS.Models;
using CommentWHUCS.Models.Services;
using Microsoft.AspNetCore.Mvc;


namespace CommentWHUCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogOnController : ControllerBase
    {
        readonly LogOnService logOnService;
        public LogOnController(LogOnService logOnService)
        {
            this.logOnService = logOnService;
        }


        //用户登录
        // GET api/<LogOnController>
        [HttpGet]
        public ActionResult<User> LogOn(string input, string password)
        {
            try
            {
                var queryEmail = logOnService.LogOn(input, password);
                return queryEmail;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //发送验证码
        // GET api/<LogOnController>/Verification
        [HttpGet("Verification")]
        public ActionResult<string> LogOn(string email)
        {
            try
            {
                return logOnService.SendCode(email);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //用户注册
        // POST api/<LogOnController>
        [HttpPost]
        public ActionResult Register(string? nickName, string email, string password, bool userType, string verificationCode, string inputCode)
        {
            try
            {
                logOnService.Register(nickName, email, password, userType, verificationCode, inputCode);
                return Content("注册成功");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
