using BrewSentinel.SignalRHub.Raw;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewSentinel.SignalRHub.Hubs
{
    [HubName("Brew")]
    public class BrewHub : Hub
    {
        private readonly IHubContext<TypedBrewHub, IClient> _context;
        private readonly IPersistentConnectionContext _rawConnectionContext;

        public BrewHub(IHubContext<TypedBrewHub, IClient> demoContext,
            IPersistentConnectionContext<RawConnection> rawConnectionContext)
        {
            _context = demoContext;
            _rawConnectionContext = rawConnectionContext;
        }

        public override async Task OnConnected()
        {
            await _rawConnectionContext.Connection.Broadcast(new
            {
                type = RawConnection.MessageType.Broadcast.ToString(),
                from = Context.ConnectionId,
                data = "Connected to BrewHub!"
            });
        }
    }
}
