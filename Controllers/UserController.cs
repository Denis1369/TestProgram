using APIWithPostgresql.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWithPostgresql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user = Program.context.Users.FirstOrDefault(user => user.Id == id);
            return user == null ? NotFound("ASD") : Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async void Post([FromBody] User user)
        {
            Program.context.Users.Add(user);
            await Program.context.SaveChangesAsync();
        }

        // PUT api/<UserController>/5
        [HttpPut("{user}")]
        public async void Put([FromBody] User user)
        {
            User user_bd = Program.context.Users.FirstOrDefault(user_f => user_f.Id == user.Id);

            user_bd.Login = user.Login;
            user_bd.Email = user.Email;
            user_bd.Pass = user.Pass;
            user_bd.Name = user.Name;
            user_bd.Sname = user.Sname;

            await Program.context.SaveChangesAsync();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            Program.context.Users.Remove(Program.context.Users.FirstOrDefault(user => user.Id == id));  // Удаляем пользователя
            await Program.context.SaveChangesAsync();  // Сохраняем изменения в базе данных
        }
    }
}
