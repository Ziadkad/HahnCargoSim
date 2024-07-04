using Backend.Model;

namespace Backend.Services.Interfaces;

public interface IUserService
{
    Task<UserToken> Login(UserAuthenticate userAuthenticate);
    Task<int> CoinAmount();
}