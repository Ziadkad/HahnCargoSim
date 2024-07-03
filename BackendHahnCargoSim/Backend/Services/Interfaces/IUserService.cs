using Backend.Model;

namespace Backend.Services.Interfaces;

public interface IUserService
{
    UserToken Login(UserAuthenticate userAuthenticate);
    int CoinAmount();
}