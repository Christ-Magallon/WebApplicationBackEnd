using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationBackEnd.Data;
using WebApplicationBackEnd.Models;
using WebApplicationBackEnd.Models.Entities;

namespace WebApplicationBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
         private readonly ApplicationDbContext dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllUser() 
        {
            return Ok(dbContext.Users.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetUserById(Guid id)
        {
            var user = dbContext.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);    
        }

        [HttpPost]
        [Route("/api/Login")]
        public IActionResult UserLogin(LoginDto loginDto)
        {
          var user = dbContext.Users
        .FirstOrDefault(logincred => logincred.Username == loginDto.Username && logincred.Password == loginDto.Password && logincred.Type == loginDto.Type);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser(AddUserDto addUserDto)
        {
            var userEntity = new User()
            {
                Id = Guid.NewGuid(),
                Username = addUserDto.Username,
                Password = addUserDto.Password,
                Type = addUserDto.Type
            };

            dbContext.Users.Add(userEntity);
            dbContext.SaveChanges();

            return Ok(userEntity);  

        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var user = dbContext.Users.Find(id);

            if(user == null)
            {
                return NotFound();
            }

            user.Username = updateUserDto.Username;
            user.Password = updateUserDto.Password;
            user.Type = updateUserDto.Type;

            dbContext.SaveChanges();

            return Ok(user);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var user = dbContext.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            return Ok(user);
        }
    }
}
