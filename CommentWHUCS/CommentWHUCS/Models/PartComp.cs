namespace CommentWHUCS.Models
{
    public class PartComp
    {
        public string Id { get; set; }
        public string GroupId { get; set; }
        public string TypeId { get; set; }

        public PartComp(string groupId, string typeId)
        {
            Id = Guid.NewGuid().ToString();
            GroupId = groupId;
            TypeId = typeId;
        }
    }
}
