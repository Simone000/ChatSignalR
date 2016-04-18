using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ChatSignalR.Hubs
{
    [HubName("chat2Hub")]
    public class Chat2Hub : Hub
    {
        private static int client_connessi = 0;
        private List<Messaggio> Messaggi = new List<Messaggio>(50);

        public override System.Threading.Tasks.Task OnConnected()
        {
            client_connessi++;
            Clients.All.OnUpdate_ClientConnessi(client_connessi);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            client_connessi--;
            Clients.All.OnUpdate_ClientConnessi(client_connessi);

            return base.OnDisconnected(stopCalled);
        }

        public void SendMsg(string msg, string autore)
        {
            this.Messaggi.Add(new Messaggio(msg, autore, DateTime.Now));
            Clients.All.OnMsgReceived(msg, autore, DateTime.Now.ToString());
        }
    }

    public class Messaggio
    {
        public string testo { get; private set; }
        public string autore { get; private set; }
        public DateTime data { get; private set; }

        public Messaggio(string testo, string autore, DateTime data)
        {
            this.testo = testo;
            this.autore = autore;
            this.data = data;
        }
    }
}