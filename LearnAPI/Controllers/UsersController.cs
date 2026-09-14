using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LearnAPI.Service.IUser;
using LearnAPI.Model;
using LearnAPI.Service.User;

namespace LearnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;


        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }


        [HttpGet("GetName")]
        public string GetName(string name)
        {
            var res = userService.GetName(name);

            return res;
        }

        [HttpGet("GetOld")]
        public int GetOld(int year)
        {
            var res = userService.GetOld(year);

            return res;
        }

        [HttpPost("SetInfo")]
        public Users SetInfo([FromBody]Users users)
        {
            var res = userService.SetInfo(users);

            return res;
        }
    }
}
