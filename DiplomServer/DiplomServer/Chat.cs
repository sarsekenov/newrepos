using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
namespace DiplomServer
{
    [Authorize]
    public class Chat : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }


    }
}