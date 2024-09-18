using AutoMapper;
using PIPlatform.UserManagar.Models;
using PIPlatform.UserManager.BL.HttpClients;
using PIPlatform.UserManager.BL.Interfaces;
using PIPlatform.UserManager.DAL.Repositories.Interfaces;
using PIPlatform.UserManager.DomainModel.Entities;

namespace PIPlatform.UserManager.BL.Implementations
{
    public class NovaUserService : INovaUserService
    {
        private readonly INovaUserRepository _novaUserRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly INovaHttpClient _novaHttpClient;

        public NovaUserService(INovaUserRepository novaUserRepository, IUnitOfWork unitOfWork, IMapper mapper, INovaHttpClient novaHttpClient)
        {
            _novaUserRepository = novaUserRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _novaHttpClient = novaHttpClient;
        }

        public async Task<NovaUserModel> Add(string token)
        {
            var response = await _novaHttpClient.GetLoyaltyInfoByApiKey(token);

            var novaUserList = await _novaUserRepository.GetAll();
            var novaUser = novaUserList.SingleOrDefault() ?? new NovaUser();

            novaUser.Ref = response.CounterpartyRef;
            novaUser.Surname = response.LastName;
            novaUser.Name = response.FirstName;
            novaUser.ContactRef = response.ContactSender;
            novaUser.Number = response.Phone;
            novaUser.Token = token;

            if(novaUserList.SingleOrDefault() == default)
            {
                await _novaUserRepository.Create(novaUser);
            }
            else
            {
                await _novaUserRepository.Update(novaUser);
            }

            await _unitOfWork.SaveAsync();

            novaUserList = await _novaUserRepository.GetAll();

            return _mapper.Map<NovaUser, NovaUserModel>(novaUserList.SingleOrDefault());
        }

        public async Task<NovaUserModel> Get()
        {
            var allUsers = await _novaUserRepository.GetAll();
            var user = allUsers.SingleOrDefault();

            if(user == null)
            {
                throw new KeyNotFoundException("User wasn`t set");
            }

            return _mapper.Map<NovaUser, NovaUserModel>(user);
        }
    }
}