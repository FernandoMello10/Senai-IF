using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiChamados.Hubs
{
    public class ChamadoHub: Hub
    {
        public async Task Announce(string chamado)
        {
            //Clients.All.SendAsync();
        }
    }
}
