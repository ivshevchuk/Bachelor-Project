using PIPlatform.UserManagar.Models.NovaHttp;

namespace PIPlatform.UserManager.BL.HttpClients
{
    public interface INovaHttpClient
    {
        Task<List<NovaGetDocumentListResponse>> GetDocumentList(NovaGetDocumentListRequest getDocumentListRequest, string token);
        Task Delete(NovaDeleteRequest novaDeleteRequest, string token);
        Task<NovaSaveResponse> Save(NovaSaveRequest novaSaveRequest, string token);
        Task<NovaUpdateResponse> Update(NovaUpdateRequest novaUpdateRequest, string token);
        Task<List<NovaGetWarehousesResponse>> GetWarehouses(NovaGetWarehousesRequest novaGetWarehousesRequest, string token);
        Task<List<NovaGetStatusDocumentsResponse>> GetStatusDocuments(NovaGetStatusDocumentsRequest novaGetStatusDocumentsRequest, string token);
        Task<List<NovaSearchSettlementsResponse>> SearchSettlements(NovaSearchSettlementsRequest novaSearchSettlementsRequest, string token);
        Task<NovaSaveCustomersResponse> SaveCustomers(NovaSaveCustomersRequest novaSaveCustomersRequest, string token);
        Task<NovaGetLoyaltyInfoByApiKeyResponse> GetLoyaltyInfoByApiKey(string token);
    }
}
