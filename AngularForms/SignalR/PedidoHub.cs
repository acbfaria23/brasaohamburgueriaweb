﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.Identity;
using AngularForms.Model;

namespace AngularForms.SignalR
{
    public class PedidoHub : Hub
    {
        public override System.Threading.Tasks.Task OnConnected()
        {
            Clients.User(Context.User.Identity.Name).atualizaSituacaoPedido(1);
            return base.OnConnected();
        }

        [HubName("HubMessage")]
        public class MyHub : Hub
        {
            public void SendMessage(string usuario, string codPedido, string situacao)
            {
                if (!String.IsNullOrEmpty(usuario))
                {
                    Clients.User(usuario).messageAdded(codPedido, situacao);
                }
                else
                {
                    Clients.All.messageAdded(codPedido, situacao);
                }
            }
        }

    }
}