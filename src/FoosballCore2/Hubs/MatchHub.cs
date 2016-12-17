﻿using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;

namespace FoosballCore2.Hubs
{
    [HubName("match")]
    public class MatchHub : Hub
    {
        public void SendMatchPlayed()
        {
            Clients.All.sayHello("sdf");
        }
    }
}