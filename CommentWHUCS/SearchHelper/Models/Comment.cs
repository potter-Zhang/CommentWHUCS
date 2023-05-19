﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SearchHelper.Models
{
    public class Comment
    {
        [Key]
        public string CommentId { get; set; }
        public string TeacherId { get; set; }
        public string UserId { get; set; }
        public string Time { get; set; }
        public string CommentType { get; set; }
        public string Content { get; set; }
        public int LikeNum { get; set; }
    }
}
