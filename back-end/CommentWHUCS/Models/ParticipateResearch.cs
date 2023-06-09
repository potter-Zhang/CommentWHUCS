using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CommentWHUCS.Models
{
    public class ParticipateResearch     //参与科研
    {
        [Key]
        public string Id { get; set; }
        public string GroupId { get; set; }
        public string ResearchTypeId { get; set; }

        public ParticipateResearch() { }
        public ParticipateResearch(string groupId, string t) 
        {
            Id = Guid.NewGuid().ToString();
            GroupId = groupId;
            ResearchTypeId = t;
        }
    }
}
