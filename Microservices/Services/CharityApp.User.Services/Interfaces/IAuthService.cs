using CharityApp.DTOS.Auth;
using CharityApp.ResponseModels;

namespace CharityApp.User.Services.Interfaces
{
    public interface IAuthService
    {
        Task<RequestResponse<string>> LoginAsync(LoginDto request);  
    }
}
