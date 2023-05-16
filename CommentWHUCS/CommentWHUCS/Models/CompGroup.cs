using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommentWHUCS.Models
{
    public class CompGroup
    {
        [Key]
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public int OwnerId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
