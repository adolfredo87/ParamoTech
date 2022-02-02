using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Data.Repositories.Implements;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Services.Implements;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
    public partial class UsersController : ControllerBase
    {
        private Sat.Recruitment.Api.Data.ApplicationDbContext dbContext;
        private Sat.Recruitment.Api.Services.Implements.UserService userService;

        public UsersController()
        {
            dbContext = new Sat.Recruitment.Api.Data.ApplicationDbContext(); userService = new UserService(new UserRepository(dbContext));
        }

        [HttpPost]
        [Route("/CreateUser")]
        public async Task<Result> CreateUser(string name, string email, string address, string phone, string userType, string money)
        {
            var errors = "";

            ValidateErrors(name, email, address, phone, ref errors);

            if (errors != null && errors != "")
                return new Result()
                {
                    IsSuccess = false,
                    Errors = errors
                };

            return await userService.RespuestaResult(name, email, address, phone, userType, money);
        }

        [HttpGet]
        [Route("/GetUsersAsync")]
        public async Task<ActionResult<List<User>>> GetUsersAsync()
		{
            return await userService.GetUsersAsync();
        }

        //Validate errors
        private void ValidateErrors(string name, string email, string address, string phone, ref string errors)
        {
            if (name == null)
                //Validate if Name is null
                errors = "The name is required";
            if (email == null)
                //Validate if Email is null
                errors = errors + " The email is required";
            if (address == null)
                //Validate if Address is null
                errors = errors + " The address is required";
            if (phone == null)
                //Validate if Phone is null
                errors = errors + " The phone is required";
        }
        
    }
}
