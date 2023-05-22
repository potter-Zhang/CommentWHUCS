using CommentWHUCS.Models.DAO;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace CommentWHUCS.Models.Services
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
            var queryEmail = dbContext.Users.SingleOrDefault(u => u.Email == input || u.NickName == input);

            if (queryEmail == null)
                throw new Exception("不存在此用户！请先完成注册");

            if (queryEmail.Password != password)
                throw new Exception("密码错误！");

            return queryEmail;
        }

        //发送验证码的方法
        public string SendCode(string addressee)
        {
            //实例化一个发送邮件类。
            MailMessage mailMessage = new MailMessage();
            //发件人邮箱地址，方法重载不同，可以根据需求自行选择。
            mailMessage.From = new MailAddress("3064325896@qq.com");
            //收件人邮箱地址。
            mailMessage.To.Add(new MailAddress(addressee));
            //邮件标题。
            mailMessage.Subject = "点评珈";
            string verificationCode = CreateCode();
            //邮件内容。
            mailMessage.Body = "您的验证码是" + verificationCode;
            //实例化一个SmtpClient类。
            SmtpClient client = new SmtpClient();
            //在这里使用的是qq邮箱，所以是smtp.qq.com，如果使用的是126邮箱，那么就是smtp.126.com。
            client.Host = "smtp.qq.com";
            //使用安全加密连接。
            client.EnableSsl = true;
            //不和请求一块发送。
            client.UseDefaultCredentials = false;
            //验证发件人身份(发件人的邮箱，邮箱里的生成授权码);
            client.Credentials = new NetworkCredential("3064325896@qq.com", "zcridfzofyhuddbi");   //到时候可以新弄一个账号，用于专门发验证码
            //发送
            client.Send(mailMessage);

            return verificationCode;
        }

        //用户注册
        public void Register(string? nickName, string email, string password, bool userType, string verificationCode/*发送的实际验证码*/, string inputCode)
        {
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

                if (Regex.IsMatch(nickName,@"@[\w\d.]+(.com|.cn)"))
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