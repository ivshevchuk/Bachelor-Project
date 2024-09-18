using PIPlatform.UserManagar.Models.NovaHttp;

namespace PIPlatform.UserManager.BL.NovaServices
{
    public interface INovaService
    {
        Task<List<NovaGetDocumentListResponse>> GetDocumentList(NovaGetDocumentListRequest novaGetDocumentListRequest);
        Task Delete(NovaDeleteRequest novaDeleteRequest);
        Task<NovaSaveResponse> Save(NovaSaveRequest novaSaveRequest);
        Task<NovaUpdateResponse> Update(NovaUpdateRequest novaUpdateRequest);
        Task<List<NovaGetWarehousesResponse>> GetWarehouses(NovaGetWarehousesRequest novaGetWarehousesRequest);
        Task<List<NovaGetStatusDocumentsResponse>> GetStatusDocuments(NovaGetStatusDocumentsRequest novaGetStatusDocumentsRequest);
        Task<List<NovaSearchSettlementsResponse>> SearchSettlements(NovaSearchSettlementsRequest novaSearchSettlementsRequest);
        Task<NovaSaveCustomersResponse> SaveCustomers(NovaSaveCustomersRequest novaSaveCustomersRequest);
    }
}
