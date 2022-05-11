using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace DiplomServer
{
    
    public class Chat : Hub
    {
        public Chat() 
        { 
            
        }
        public void Hello()
        {
            Clients.All.hello();
        }


    }
}