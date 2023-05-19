using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SearchHelper.Models
{
    public class TeachStar
    {
        [Key]
        public string Id { get; set; }
        public string TeacherId { get; set; }
        public string UserId { get; set; }
        public double TotalStar { get; set; }
        public int ScoreStar { get; set; }     //给分情况
        public int TeachingStar { get; set; }  //授课质量
        public int TaskStar { get; set; }      //课后任务
        public int CommStar { get; set; }      //课下交流
    }
}
