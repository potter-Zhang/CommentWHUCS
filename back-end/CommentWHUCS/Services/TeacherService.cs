using CommentWHUCS.DAO;
using CommentWHUCS.Models;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace CommentWHUCS.Services
{
    public class TeacherService
    {
        private CWCDbContext _ctx;

        public TeacherService(CWCDbContext ctx)
        {
            _ctx = ctx;
        }

        // 根据name和title返回teacher列表
        public List<Teacher> Search(string name = "", string title = "")
        {
            if (_ctx.Teachers == null)
            {
                throw new Exception("context.teachers is null");
            }
            return _ctx.Teachers.Where(o => o.Name.Contains(name) && o.Title.Contains(title)).ToList();
        }

    }
}
