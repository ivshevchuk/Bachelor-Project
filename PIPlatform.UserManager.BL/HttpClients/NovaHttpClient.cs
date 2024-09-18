using Newtonsoft.Json;
using PIPlatform.UserManagar.Models.NovaHttp;
using System.Text;

namespace PIPlatform.UserManager.BL.HttpClients
{
    public class NovaHttpClient : INovaHttpClient
    {
        private readonly HttpClient _httpClient;

        public NovaHttpClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<NovaGetDocumentListResponse>> GetDocumentList (NovaGetDocumentListRequest getDocumentListRequest, string token)
        {
            var novaBaseRequest = new NovaBaseRequest(token, "InternetDocument", "getDocumentList", getDocumentListRequest);
            var request = JsonConvert.SerializeObject(novaBaseRequest);

            var content = new StringContent(request, Encoding.UTF8, "application/json");
            var url = "https://api.novaposhta.ua/v2.0/json/";

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get document list request returned exception. StatusCode={response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<NovaBaseResponse<NovaGetDocumentListResponse>>(responseContent);

            return result.data.ToList();
        }

        public async Task Delete(NovaDeleteRequest novaDeleteRequest, string token)
        {
            var novaBaseRequest = new NovaBaseRequest(token, "InternetDocument", "delete", novaDeleteRequest);
            var request = JsonConvert.SerializeObject(novaBaseRequest);

            var content = new StringContent(request, Encoding.UTF8, "application/json");
            var url = "https://api.novaposhta.ua/v2.0/json/";

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Deleting returned exception. StatusCode={response.StatusCode}");
            }
        }

        public async Task<NovaSaveResponse> Save(NovaSaveRequest novaSaveRequest, string token)
        {
            var novaBaseRequest = new NovaBaseRequest(token, "InternetDocument", "save", novaSaveRequest);
            var request = JsonConvert.SerializeObject(novaBaseRequest);

            var content = new StringContent(request, Encoding.UTF8, "application/json");
            var url = "https://api.novaposhta.ua/v2.0/json/";

            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Saving returned exception. StatusCode={response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<NovaBaseResponse<NovaSaveResponse>>(responseContent);

            return result.data.SingleOrDefault();
        }

        public async Task<NovaUpdateResponse> Update(NovaUpdateRequest novaUpdateRequest, string token)
        {
            var novaBaseRequest = new NovaBaseRequest(token, "InternetDocument", "update", novaUpdateRequest);
            var request = JsonConvert.SerializeObject(novaBaseRequest);

            var content = new StringContent(request, Encoding.UTF8, "application/json");
            var url = "https://api.novaposhta.ua/v2.0/json/";

            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Updating returned exception. StatusCode={response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<NovaBaseResponse<NovaUpdateResponse>>(responseContent);

            return result.data.SingleOrDefault();
        }

        public async Task<List<NovaGetWarehousesResponse>> GetWarehouses(NovaGetWarehousesRequest novaGetWarehousesRequest, string token)
        {
            var novaBaseRequest = new NovaBaseRequest(token, "AddressGeneral", "getWarehouses", novaGetWarehousesRequest);
            var request = JsonConvert.SerializeObject(novaBaseRequest);

            var content = new StringContent(request, Encoding.UTF8, "application/json");
            var url = "https://api.novaposhta.ua/v2.0/json/";

            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error. StatusCode={response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<NovaBaseResponse<NovaGetWarehousesResponse>>(responseContent);

            return result.data.ToList();
        }

        public async Task<List<NovaGetStatusDocumentsResponse>> GetStatusDocuments(NovaGetStatusDocumentsRequest novaGetStatusDocumentsRequest, string token)
        {
            var novaBaseRequest = new NovaBaseRequest(token, "TrackingDocument", "getStatusDocuments", novaGetStatusDocumentsRequest);
            var request = JsonConvert.SerializeObject(novaBaseRequest);

            var content = new StringContent(request, Encoding.UTF8, "application/json");
            var url = "https://api.novaposhta.ua/v2.0/json/";

            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error. StatusCode={response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<NovaBaseResponse<NovaGetStatusDocumentsResponse>>(responseContent);

            return result.data.ToList();
        }

        public async Task<List<NovaSearchSettlementsResponse>> SearchSettlements(NovaSearchSettlementsRequest novaSearchSettlementsRequest, string token)
        {
            var novaBaseRequest = new NovaBaseRequest(token, "Address", "searchSettlements", novaSearchSettlementsRequest);
            var request = JsonConvert.SerializeObject(novaBaseRequest);

            var content = new StringContent(request, Encoding.UTF8, "application/json");
            var url = "https://api.novaposhta.ua/v2.0/json/";

            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error. StatusCode={response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<NovaBaseResponse<NovaSearchSettlementsResponse>>(responseContent);

            return result.data.ToList();
        }

        public async Task<NovaSaveCustomersResponse> SaveCustomers(NovaSaveCustomersRequest novaSaveCustomersRequest, string token)
        {
            var novaBaseRequest = new NovaBaseRequest(token, "ContactPerson", "save", novaSaveCustomersRequest);
            var request = JsonConvert.SerializeObject(novaBaseRequest);

            var content = new StringContent(request, Encoding.UTF8, "application/json");
            var url = "https://api.novaposhta.ua/v2.0/json/";

            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error. StatusCode={response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<NovaBaseResponse<NovaSaveCustomersResponse>>(responseContent);

            return result.data.SingleOrDefault();
        }

        public async Task<NovaGetLoyaltyInfoByApiKeyResponse> GetLoyaltyInfoByApiKey(string token)
        {
            var novaBaseRequest = new NovaBaseRequest(token, "LoyaltyUser", "getLoyaltyInfoByApiKey", new MethodProperties());
            var request = JsonConvert.SerializeObject(novaBaseRequest);

            var content = new StringContent(request, Encoding.UTF8, "application/json");
            var url = "https://api.novaposhta.ua/v2.0/json/";

            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error. StatusCode={response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<NovaBaseResponse<NovaGetLoyaltyInfoByApiKeyResponse>>(responseContent);

            return result.data.SingleOrDefault();
        }
    }
}
