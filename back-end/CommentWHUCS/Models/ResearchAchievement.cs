using System.ComponentModel.DataAnnotations;

namespace CommentWHUCS.Models
{
    public class ResearchAchievement      //科研成果
    {
        [Key]
        public string Id { get; set; }
        public string TeacherId { get; set; }
        public string ResearchTypeId { get; set; }   //科研方向Id
        public int Year { get; set; }
        public string Achievement { get; set; }

        public ResearchAchievement() { }
        public ResearchAchievement(string teacherId, string TypeId, int year, string achievement) 
        {
            Id = Guid.NewGuid().ToString();
            TeacherId = teacherId;
            this.ResearchTypeId = TypeId;
            Year = year;
            Achievement = achievement;
        }
    }
}
