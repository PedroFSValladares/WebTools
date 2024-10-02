using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebTools.Requests.User;
using WebTools.Services.Interfaces;

namespace WebTools.Controllers.User.Create
{
    public class UserController : Controller
    {

        private readonly PasswordHasher<Models.User> passwordHasher;
        private readonly IFileManager fileManager;

        public UserController(PasswordHasher<Models.User> passwordHasher, IFileManager fileManager) {
            this.passwordHasher = passwordHasher;
            this.fileManager = fileManager;
            this.fileManager.Configure(
                Path.GetDirectoryName(Environment.ProcessPath), Environment.GetEnvironmentVariable("userListFolderName"));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserRequest createUserRequest) {
            var usersListJson = fileManager.GetFileText("users.json");
            var userList = JsonSerializer.Deserialize<Dictionary<string, Models.User>>(usersListJson);
            var user = createUserRequest.User;
            
            if(userList.ContainsKey(user.Name)) {
                return View(new CreateUserRequest {
                    User = new Models.User { Name = user.Name, Password = string.Empty },
                    ErrorMessage = "This user already exists"
                });
            }
            
            user.Password = passwordHasher.HashPassword(user, user.Password);
            userList.Add(user.Name, user);

            string userJson = JsonSerializer.Serialize(userList);
            fileManager.Save("users.json", userJson, true);

            return Ok();
        }
    }
}
