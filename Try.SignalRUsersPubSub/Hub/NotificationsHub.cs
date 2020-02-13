namespace Try.SignalRUsersPubSub.Hub
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;

    [Authorize]
    public class NotificationsHub : Hub
    {
    }
}
