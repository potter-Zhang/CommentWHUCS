using System.ComponentModel.DataAnnotations;

namespace CommentWHUCS.Models
{
    public class User       //用户
    {
        [Key]
        public string UserId { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool UserType { get; set; }   //此项为0，为普通用户；为1，则为教师用户

        public User(string nickName, string email, string password, bool userType)
        {
            UserId = Guid.NewGuid().ToString();
            NickName = nickName;
            Email = email; 
            Password = password; 
            UserType = userType;
        }
    }
}
