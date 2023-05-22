using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommentWHUCS.Models
{
    public class RSRCHGroup
    {
        [Key]
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public string TeacherId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public RSRCHGroup(string groupName, string teacherId, string title, string text)
        {
            GroupId = Guid.NewGuid().ToString();
            GroupName = groupName;
            TeacherId = teacherId;
            Title = title;
            Text = text;
        }
    }
}
