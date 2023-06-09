using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommentWHUCS.Models
{
    public class ResearchGroup       //科研团队
    {
        [Key]
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public string Teachers { get; set; }
        public string Text { get; set; }

        public ResearchGroup(string groupName, string teachers, string text)
        {
            GroupId = Guid.NewGuid().ToString();
            GroupName = groupName;
            Teachers = teachers;
            Text = text;
        }
    }
}
