using System.ComponentModel.DataAnnotations;

namespace CommentWHUCS.Models
{
    public class RSRCHType
    {
        [Key]
        public string Id { get; set; }
        public string GeneralDir { get; set; }   //科研大方向
        public string DetailedDir { get; set; }  //科研小方向
    }
}
