﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommentWHUCS.Models
{
    public class CompetitionAward       //竞赛得奖信息
    {
        [Key]
        public string CompetitionId { get; set; }
        public string TeacherId { get; set; }
        public string CompetitionTypeId { get; set; }
        public int Year { get; set; }
        public string Session { get; set; }  //届数
        public string Track { get; set; }    //竞赛赛道
        public string Region { get; set; }   //赛区
        public string Award { get; set; }    //奖项
    }
}
