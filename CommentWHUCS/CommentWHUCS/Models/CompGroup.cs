using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommentWHUCS.Models
{
    public class CompGroup
    {
        [Key]
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public string OwnerId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public CompGroup(string groupName, string ownerId, string title, string text) 
        {
            GroupId = Guid.NewGuid().ToString();
            GroupName = groupName;
            OwnerId = ownerId;
            Title = title;
            Text = text;
        }
    }
}
