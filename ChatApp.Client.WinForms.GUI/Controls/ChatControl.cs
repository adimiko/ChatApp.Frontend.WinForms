using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp.Client.WinForms.GUI.Controls
{
    public partial class ChatControl : UserControl
    {
        public ChatControl()
        {
            InitializeComponent();
            
        }

        public void AddMessage(string message)
        {
            ChatListBox.Items.Add(message);
        }

        public void SendMessage()
        {

        }
    }
}
