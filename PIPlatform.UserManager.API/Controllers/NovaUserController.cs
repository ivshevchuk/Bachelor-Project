using Microsoft.AspNetCore.Mvc;
using PIPlatform.UserManagar.Models;
using PIPlatform.UserManager.BL.Interfaces;

namespace PIPlatform.UserManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NovaUserController : ControllerBase
    {
        private readonly INovaUserService _novaUserService;

        public NovaUserController(INovaUserService novaUserService)
        {
            _novaUserService = novaUserService;
        }

        [HttpPost("[action]/token")]
        public async Task<NovaUserModel> Add(string token)
        {
            return await _novaUserService.Add(token);
        }

        [HttpGet("[action]")]
        public async Task<NovaUserModel> Get()
        {
            return await _novaUserService.Get();
        }
    }
}
