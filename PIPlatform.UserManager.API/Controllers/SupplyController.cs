using Microsoft.AspNetCore.Mvc;
using PIPlatform.UserManagar.Models;
using PIPlatform.UserManager.BL.Interfaces;

namespace PIPlatform.UserManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplyController : ControllerBase
    {
        private readonly ISupplyService _supplyService;

        public SupplyController(ISupplyService supplyService)
        {
            _supplyService = supplyService;
        }

        [HttpDelete("[action]")]
        public async Task<bool> DeleteById(int id)
        {
            return await _supplyService.DeleteById(id);
        }

        [HttpPost("[action]")]
        public async Task<SupplyModel> Add(CreateSupplyModel supplyModel)
        {
            return await _supplyService.Add(supplyModel);
        }

        [HttpGet("[action]/{dateTime}")]
        public async Task<IEnumerable<SupplyModel>> Search(DateTime dateTime)
        {
            return await _supplyService.Search(dateTime);
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<SupplyModel>> GetAll()
        {
            return await _supplyService.GetAll();
        }
    }
}
