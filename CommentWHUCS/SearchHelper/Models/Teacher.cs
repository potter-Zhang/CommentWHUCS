using System.ComponentModel.DataAnnotations;

namespace SearchHelper.Models
{
    public class Teacher
    {
        [Key]
        public string TeacherId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string ResFields { get; set; }
        public string ResGroupId { get; set; }   //科研团队ID
        public string DBLPLink { get; set; }
    }
}
