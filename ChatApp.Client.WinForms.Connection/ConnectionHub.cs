using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Client.WinForms.Connection
{
    public class ConnectionHub
    {
        public readonly HubConnection Connection;

        public delegate void ReceiveMessage(string message);
        public event ReceiveMessage MessageReceived;

        public delegate void StartChatting();
        public event StartChatting ChattingStarted;

        public delegate void StopChatting();
        public event StopChatting ChattingStopped;

        public ConnectionHub()
        {
            Connection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:5001/hubs/chat"))
            .WithAutomaticReconnect()
            .Build();
            RegisterProcedures();
        }

        private void RegisterProcedures()
        {
            Connection.On<string>("ReceiveMessage", message => MessageReceived?.Invoke(message));
            Connection.On("StartChatting", () => ChattingStarted?.Invoke());
            Connection.On("StopChatting", () => ChattingStopped?.Invoke());
        }

        public async Task Connect()
            => await Connection.StartAsync();

        public async Task JoinToLobby()
            => await Connection.InvokeAsync("JoinToLobby");

        public async Task SendMessage(string message)
            => await Connection.InvokeAsync("SendMessage", message);

        public async Task Disconnect()
            => await Connection.StopAsync();

    }
}
