using Microsoft.AspNetCore.Mvc;
using PIPlatform.UserManagar.Models.NovaHttp;
using PIPlatform.UserManager.BL.NovaServices;

namespace PIPlatform.UserManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NovaController : ControllerBase
    {
        private readonly INovaService _novaService;

        public NovaController(INovaService novaService)
        {
            _novaService = novaService;
        }

        [HttpPost("[action]")]
        public async Task<List<NovaGetDocumentListResponse>> GetDocumentList(NovaGetDocumentListRequest novaGetDocumentListRequest)
        {
            return await _novaService.GetDocumentList(novaGetDocumentListRequest);
        }

        [HttpPost("[action]")]
        public async Task Delete(NovaDeleteRequest novaDeleteRequest)
        {
            await _novaService.Delete(novaDeleteRequest);
        }

        [HttpPost("[action]")]
        public async Task<NovaSaveResponse> Save(NovaSaveRequest novaSaveRequest)
        {
            return await _novaService.Save(novaSaveRequest);
        }

        [HttpPost("[action]")]
        public async Task<NovaUpdateResponse> Update(NovaUpdateRequest novaUpdateRequest)
        {
            return await _novaService.Update(novaUpdateRequest);
        }

        [HttpPost("[action]")]
        public async Task<List<NovaGetWarehousesResponse>> GetWarehouses(NovaGetWarehousesRequest novaGetWarehousesRequest)
        {
            return await _novaService.GetWarehouses(novaGetWarehousesRequest);
        }

        [HttpPost("[action]")]
        public async Task<List<NovaGetStatusDocumentsResponse>> GetStatusDocuments(NovaGetStatusDocumentsRequest novaGetStatusDocumentsRequest)
        {
            return await _novaService.GetStatusDocuments(novaGetStatusDocumentsRequest);
        }

        [HttpPost("[action]")]
        public async Task<List<NovaSearchSettlementsResponse>> SearchSettlements(NovaSearchSettlementsRequest novaSearchSettlementsRequest)
        {
            return await _novaService.SearchSettlements(novaSearchSettlementsRequest);
        }

        [HttpPost("[action]")]
        public async Task<NovaSaveCustomersResponse> SaveCustomers(NovaSaveCustomersRequest novaSaveCustomersRequest)
        {
            return await _novaService.SaveCustomers(novaSaveCustomersRequest);
        }
    }
}
