using Org.BouncyCastle.Asn1.Mozilla;
using System.ComponentModel.DataAnnotations;

namespace SearchHelper.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool UserType { get; set; }
    }
}
