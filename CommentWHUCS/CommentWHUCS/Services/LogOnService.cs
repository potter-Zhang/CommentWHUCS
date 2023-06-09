using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using CommentWHUCS.DAO;
using CommentWHUCS.Models;

namespace CommentWHUCS.Services
{
    public class LogOnService
    {
        readonly CWCDbContext dbContext;
        public LogOnService(CWCDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //用户登录
        public User? LogOn(string input, string password)
        {
            var query = dbContext.Users.SingleOrDefault(u => u.Email == input || u.NickName == input);

            if (query == null)
                throw new Exception("不存在此用户！请先完成注册");

            if (query.Password != password)
                throw new Exception("密码错误！");

            return query;
        }

        //发送验证码的方法
        public string SendCode(string addressee)
        {
            MailMessage mailMessage = new MailMessage();

            //发件人邮箱地址
            mailMessage.From = new MailAddress("3064325896@qq.com");
            //收件人邮箱地址
            mailMessage.To.Add(new MailAddress(addressee));

            mailMessage.Subject = "点评珈";
            string verificationCode = CreateCode();
            //邮件内容
            mailMessage.Body = "您的验证码是" + verificationCode;
            
            SmtpClient client = new SmtpClient();

            client.Host = "smtp.qq.com";
           
            client.EnableSsl = true;
           
            client.UseDefaultCredentials = false;

            //验证发件人身份(发件人的邮箱，邮箱里的生成授权码)
            client.Credentials = new NetworkCredential("3064325896@qq.com", "zcridfzofyhuddbi");
            
            client.Send(mailMessage);

            return verificationCode;
        }

        //用户注册
        public void Register(string? nickName, string email, string password, bool userType, string verificationCode/*发送的实际验证码*/, string inputCode)
        {
            if (!Regex.IsMatch(email, @"\d{13}@whu.edu.cn"))
                throw new Exception("邮箱应为武汉大学邮箱");

            var queryEmail = dbContext.Users.SingleOrDefault(u => u.Email == email);
            if (queryEmail != null)
                throw new Exception("此邮箱已有绑定账号");

            string name;

            if (userType)   //注册用户为教师时
            {
                var queryTEmail = dbContext.Teachers.SingleOrDefault(t => t.Email == email);
                if (queryTEmail == null)
                    throw new Exception("您输入的邮箱并非教师邮箱！");

                name = queryTEmail.Name;
            }
            else           //注册用户为普通用户时
            {
                var queryName = dbContext.Users.SingleOrDefault(u => u.NickName == nickName);
                if (queryName != null)
                    throw new Exception("此昵称已被占用");

                if (nickName == null)
                    throw new Exception("昵称不能为空");

                if (Regex.IsMatch(nickName, @"@[\w\d.]+(.com|.cn)"))
                    throw new Exception("昵称格式不合法（不能为类似邮箱的格式）");

                name = nickName;
            }

            if (verificationCode != inputCode)
                throw new Exception("验证码错误");

            User u = new User(name, email, password, userType);
            dbContext.Users.Add(u);
            dbContext.SaveChanges();
        }

        //生成6位数字验证码
        private string CreateCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}