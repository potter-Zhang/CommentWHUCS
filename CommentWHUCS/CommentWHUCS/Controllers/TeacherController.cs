using Microsoft.AspNetCore.Mvc;
using CommentWHUCS.Models;
using CommentWHUCS.SearchHelper;


namespace CommentWHUCS.Controllers
{
    [Route("api/teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        Searcher searcher;
        Inserter inserter;
        public TeacherController(Searcher searcher, Inserter inserter)
        {
            this.searcher = searcher;
            this.inserter = inserter;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public List<Teacher> GetTeachers(string name)
        {
            return Searcher.SearchTeachers(name, "");
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
