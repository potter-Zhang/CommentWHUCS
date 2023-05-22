using System.ComponentModel.DataAnnotations;

namespace CommentWHUCS.Models
{
    public class CompStar
    {
        [Key]
        public string Id { get; set; }
        public string TeacherId { get; set; }
        public string UserId { get; set; }
        public double TotalStar { get; set; }
        public int ExpStar { get; set; }       //带队经验
        public int FundsStar { get; set; }     //经费支持
        public int ResStar { get; set; }       //资源人脉
        public int TeachingStar { get; set; }  //教学能力
    }
}
