namespace SearchHelper.Models
{
    public class CompType
    {
        public string CompTypeId { get; set; }   //竞赛类型ID
        public string CompName { get; set; }     //竞赛名称
        public string FirstType { get; set; }    //竞赛形式一级
        public string SecondType { get; set; }   //竞赛形式二级
        public string BonusType { get; set; }    //加分等级
    }
}
