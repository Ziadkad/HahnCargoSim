using Backend.Services.Interfaces;
using Backend.UnitOfService.Interfaces;

namespace Backend.UnitOfService;

public class UnitOfServices : IUnitOfServices
{
    public ICargoTransporterService CargoTransporter { get; }
    public IGridService Grid { get; }
    public IOrderService Order { get; }
    public ISimService Sim { get; }
    public IUserService User { get; }

    public UnitOfServices(
        ICargoTransporterService cargoTransporter,
        IGridService grid,
        IOrderService order,
        ISimService sim,
        IUserService user)
    {
        CargoTransporter = cargoTransporter;
        Grid = grid;
        Order = order;
        Sim = sim;
        User = user;
    }
}