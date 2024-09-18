using PIPlatform.UserManagar.Models.NovaHttp;
using PIPlatform.UserManager.BL.HttpClients;
using PIPlatform.UserManager.DAL.Repositories.Interfaces;

namespace PIPlatform.UserManager.BL.NovaServices
{
    public class NovaService : INovaService
    {
        private readonly INovaHttpClient _novaHttpClient;
        private readonly INovaUserRepository _novaUserRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NovaService(INovaHttpClient novaHttpClient, INovaUserRepository novaUserRepository, IUnitOfWork unitOfWork)
        {
            _novaHttpClient = novaHttpClient;
            _novaUserRepository = novaUserRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<NovaGetDocumentListResponse>> GetDocumentList(NovaGetDocumentListRequest novaGetDocumentListRequest)
        {
            var novaUserList = await _novaUserRepository.GetAll();
            var novaUser = novaUserList.SingleOrDefault();

            if (novaUser == null)
            {
                throw new Exception("User isn`t configured.");
            }

            var document = await _novaHttpClient.GetDocumentList(novaGetDocumentListRequest, novaUser.Token);

            if(document == null)
            {
                throw new Exception("Nothing was found");
            }

            return document;
        }

        public async Task Delete(NovaDeleteRequest novaDeleteRequest)
        {
            var novaUserList = await _novaUserRepository.GetAll();
            var novaUser = novaUserList.SingleOrDefault();

            if (novaUser == null)
            {
                throw new Exception("User isn`t configured.");
            }

            await _novaHttpClient.Delete(novaDeleteRequest, novaUser.Token);
        }

        public async Task<NovaSaveResponse> Save(NovaSaveRequest novaSaveRequest)
        {
            var novaUserList = await _novaUserRepository.GetAll();
            var novaUser = novaUserList.SingleOrDefault();

            if (novaUser == null)
            {
                throw new Exception("User isn`t configured.");
            }

            var document = await _novaHttpClient.Save(novaSaveRequest, novaUser.Token);

            if (document == null)
            {
                throw new Exception("Something went wrong");
            }

            novaUser.City = novaSaveRequest.CitySender;
            novaUser.Warehouse = novaSaveRequest.SenderAddress;

            await _novaUserRepository.Update(novaUser);
            await _unitOfWork.SaveAsync();

            return document;
        }

        public async Task<NovaUpdateResponse> Update(NovaUpdateRequest novaUpdateRequest)
        {
            var novaUserList = await _novaUserRepository.GetAll();
            var novaUser = novaUserList.SingleOrDefault();

            if (novaUser == null)
            {
                throw new Exception("User isn`t configured.");
            }

            var document = await _novaHttpClient.Update(novaUpdateRequest, novaUser.Token);

            if (document == null)
            {
                throw new Exception("Something went wrong");
            }

            return document;
        }

        public async Task<List<NovaGetWarehousesResponse>> GetWarehouses(NovaGetWarehousesRequest novaGetWarehousesRequest)
        {
            var novaUserList = await _novaUserRepository.GetAll();
            var novaUser = novaUserList.SingleOrDefault();

            if (novaUser == null)
            {
                throw new Exception("User isn`t configured.");
            }

            var document = await _novaHttpClient.GetWarehouses(novaGetWarehousesRequest, novaUser.Token);

            if (document == null)
            {
                throw new Exception("Something went wrong");
            }

            return document;
        }

        public async Task<List<NovaGetStatusDocumentsResponse>> GetStatusDocuments(NovaGetStatusDocumentsRequest novaGetStatusDocumentsRequest)
        {
            var novaUserList = await _novaUserRepository.GetAll();
            var novaUser = novaUserList.SingleOrDefault();

            if (novaUser == null)
            {
                throw new Exception("User isn`t configured.");
            }

            var document = await _novaHttpClient.GetStatusDocuments(novaGetStatusDocumentsRequest, novaUser.Token);

            if (document == null)
            {
                throw new Exception("Something went wrong");
            }

            return document;
        }

        public async Task<List<NovaSearchSettlementsResponse>> SearchSettlements(NovaSearchSettlementsRequest novaSearchSettlementsRequest)
        {
            var novaUserList = await _novaUserRepository.GetAll();
            var novaUser = novaUserList.SingleOrDefault();

            if (novaUser == null)
            {
                throw new Exception("User isn`t configured.");
            }

            var document = await _novaHttpClient.SearchSettlements(novaSearchSettlementsRequest, novaUser.Token);

            if (document == null)
            {
                throw new Exception("Something went wrong");
            }

            return document;
        }

        public async Task<NovaSaveCustomersResponse> SaveCustomers(NovaSaveCustomersRequest novaSaveCustomersRequest)
        {
            var novaUserList = await _novaUserRepository.GetAll();
            var novaUser = novaUserList.SingleOrDefault();

            if (novaUser == null)
            {
                throw new Exception("User isn`t configured.");
            }

            var document = await _novaHttpClient.SaveCustomers(novaSaveCustomersRequest, novaUser.Token);

            if (document == null)
            {
                throw new Exception("Something went wrong");
            }

            return document;
        }
    }
}
