using Microsoft.AspNetCore.SignalR;

namespace Backend.Hub;

public class SimHub : Microsoft.AspNetCore.SignalR.Hub
{
    private static int _counter = 0;
    private readonly Timer _timer;
    private readonly IHubContext<SimHub> _hubContext;

    public SimHub(IHubContext<SimHub> hubContext)
    {
        _hubContext = hubContext;
        _timer = new Timer(UpdateCounter, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1)); // Adjust interval as needed
    }

    private void UpdateCounter(object state)
    {
        _counter++;
        _hubContext.Clients.All.SendAsync("ReceiveCounter", _counter);
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        // Dispose timer on hub disconnect
        _timer.Dispose();
        return base.OnDisconnectedAsync(exception);
    }
    
    
    
}