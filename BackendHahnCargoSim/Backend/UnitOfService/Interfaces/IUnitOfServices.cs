using Backend.Services.Interfaces;

namespace Backend.UnitOfService.Interfaces;

public interface IUnitOfServices
{
    ICargoTransporterService CargoTransporter { get; }
    IGridService Grid { get; }
    IOrderService Order { get; }
    ISimService Sim { get; }
    IUserService User { get; }
}