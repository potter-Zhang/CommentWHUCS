using System.ComponentModel.DataAnnotations;

namespace CommentWHUCS.Models
{
    public class PartRSRCH
    {
        [Key]
        public string Id { get; set; }
        public string GroupId { get; set; }
        public string TypeId { get; set; }

        public PartRSRCH(string groupId, string typeId)
        {
            Id = Guid.NewGuid().ToString();
            GroupId = groupId;
            TypeId = typeId;
        }
    }
}
