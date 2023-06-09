using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommentWHUCS.Models
{
    public class CompetitionGroup       //竞赛团队（竞赛招募）信息
    {
        [Key]
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public string CompetitionTypeId { get; set; }
        public string Participants { get; set; }
        public string Text { get; set; }

        public CompetitionGroup(string groupName, string competitionTypeId, string participants, string text) 
        {
            GroupId = Guid.NewGuid().ToString();
            GroupName = groupName;
            CompetitionTypeId = competitionTypeId;
            Participants = participants;
            Text = text;
        }
    }
}
