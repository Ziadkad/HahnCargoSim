namespace Backend.Services.Interfaces;

public interface ISimService
{
    Task Start(string token);
    Task Stop(string token);
}