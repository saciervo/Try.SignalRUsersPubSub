namespace Try.SignalRUsersPubSub.Services.SignalR
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.SignalR;

    public class NameBasedUserIdProvider : IUserIdProvider
    {
        public virtual string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.FindFirst(ClaimTypes.Name)?.Value;
        }
    }
}