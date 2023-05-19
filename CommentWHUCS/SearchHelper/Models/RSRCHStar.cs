namespace SearchHelper.Models
{
    public class RSRCHStar
    {
        public string Id { get; set; }
        public string TeacherId { get; set; }
        public string UserId { get; set; }
        public double TotalStar { get; set; }
        public int ACStar { get; set; }         //学术水平
        public int FundsStar { get; set; }      //经费支持
        public int ResStar { get; set; }        //资源人脉
        public int CharStar { get; set; }       //个人性格
    }
}
