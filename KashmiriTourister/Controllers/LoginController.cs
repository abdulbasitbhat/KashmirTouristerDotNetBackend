using KashmiriTourister.Data;
using KashmiriTourister.Models;
using KashmiriTourister.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace KashmiriTourister.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public LoginController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("alllogin")]
        public IActionResult alllogin()
        {
            var Users = dbContext.Login.ToList();
            return Ok(Users);
        }

        [HttpGet]
        [Route("loginDetails/id/{email}")]
        public IActionResult loginDetails(String email)
        {
            var req = dbContext.Login.Find(email);
            if (req is null)
            {
                return NotFound();
            }
            return Ok(req);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult login(AddLoginDTO addLoginDTO)
        {
            var User = dbContext.Login.Find(addLoginDTO.email);
            if (User is null)
            {
                var newUser = new Login()
                {
                    email = addLoginDTO.email,
                    name = addLoginDTO.name,
                    collection = addLoginDTO.collection
                };
                dbContext.Login.Add(newUser);
                dbContext.SaveChanges();
                return Ok(newUser);
            }
            return Ok(User);
        }

        [HttpPut]
        [Route("updateUser")]
        public IActionResult UpdateUser(UpdateLoginDTO updateLoginDTO)
        {
            var user = dbContext.Login.Find(updateLoginDTO.email);
            if (user is null)
            {
                return NotFound($"User  with email {updateLoginDTO.email} not found.");
            }

            if (updateLoginDTO.name != "")
            {
                user.name = updateLoginDTO.name;
            }
            if (updateLoginDTO.collection.Length != 0 && updateLoginDTO.collection[0] != "empty")
            {
                user.collection = updateLoginDTO.collection;
            }
            if (updateLoginDTO.collection.Length != 0 && updateLoginDTO.collection[0] == "empty")
            {
                user.collection = [];
            }

            dbContext.SaveChanges();

            return Ok(user);
        }
    }
}
