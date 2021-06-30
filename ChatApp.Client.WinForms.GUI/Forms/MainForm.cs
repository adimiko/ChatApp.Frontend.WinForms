using ChatApp.Client.WinForms.Connection;
using ChatApp.Client.WinForms.GUI.Controls;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp.Client.WinForms.GUI.Forms
{
    public partial class MainForm : Form
    {
        private readonly HubConnection _connection;
        private readonly ChatControl _chatControl;
        public MainForm()
        {
            var connection = new HubConnectionBuilder()
                   .WithUrl(new Uri("https://localhost:5001/hubs/chat"))
                   .Build();

            InitializeComponent();
            _connection = connection;
            _chatControl = new ChatControl();

        }

        private async void JoinToLobbyButton_Click(object sender, EventArgs e)
        {
            await _connection.InvokeAsync("JoinToLobby");
            ClickButtonLabel.Text = "We looking for person for you...";
            JoinToLobbyButton.Hide();

        }

        private void StartChatting()
        {
            ClickButtonLabel.Hide();
            _chatControl.Dock = DockStyle.Fill;
            ContentPanel.Controls.Add(_chatControl);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            _connection.On<string>("ReceiveMessage", message =>
            {
                
            });

            _connection.On<string>("StartChatting", message =>
            {
                StartChatting();
            });


            try
            {
                await _connection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
