using CommentWHUCS.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Microsoft.AspNetCore.Http;


namespace CommentWHUCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        //获取登录后用户id
        // GET: api/<SessionController>/UserId
        [HttpGet("UserId")]
        public ActionResult<string> GetUserId()
        {
            return HttpContext.Session.GetString("UserId");
        }

        //获取登录后用户昵称
        // GET: api/<SessionController>/NickName
        [HttpGet("NickName")]
        public ActionResult<string> GetNicKName()
        {
            return HttpContext.Session.GetString("NickName");
        }

        //获取登录后用户邮箱
        // GET: api/<SessionController>/Email
        [HttpGet("Email")]
        public ActionResult<string> GetEmail()
        {
            return HttpContext.Session.GetString("Email");
        }

        //获取登录后用户类型（true为教师）
        // GET: api/<SessionController>/UserType
        [HttpGet("UserType")]
        public ActionResult<bool> GetUserType()
        {
            return (HttpContext.Session.GetString("UserType") == "1");       
        }

        //登录后，应调用此方法，将登录用户的信息存入session
        // POST: api/<SessionController>
        [HttpPost]
        public ActionResult PostSession(User user)
        {
            try
            {
                HttpContext.Session.SetString("UserId", user.UserId);
                HttpContext.Session.SetString("NickName", user.NickName);
                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetString("UserType", user.UserType ? "1" : "0");
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
