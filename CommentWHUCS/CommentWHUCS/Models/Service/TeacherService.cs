using CommentWHUCS.Models.DAO;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace CommentWHUCS.Models.Service
{
    public class TeacherService
    {
        private CWCDbContext _ctx;

        public TeacherService(CWCDbContext ctx)
        {
            _ctx = ctx;
        }

        
        public async Task<List<Teacher>> Search(string name = "", string title = "")
        {
            if (_ctx.Teachers == null)
            {
                throw new Exception("context.teachers is null");
            }
            return await _ctx.Teachers.Where(o => o.Name.Contains(name) && o.Title.Contains(title)).ToListAsync();
        }

    }
}
