using System.ComponentModel.DataAnnotations;

namespace CommentWHUCS.Models
{
    public class RSRCHInfo
    {
        [Key]
        public string Id { get; set; }
        public string TeacherId { get; set; }
        public string RSRCHTypeId { get; set; }   //科研方向Id
        public int Year { get; set; }
        public string Achievement { get; set; }

        public RSRCHInfo(string teacherId, string RSRCHTypeId, int year, string achievement) 
        {
            Id = Guid.NewGuid().ToString();
            TeacherId = teacherId;
            this.RSRCHTypeId = RSRCHTypeId;
            Year = year;
            Achievement = achievement;
        }
    }
}
