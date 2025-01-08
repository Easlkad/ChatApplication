using ChatApplication.Net;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChatApplication
{
    public partial class Form1 : Form
    {
        ViewModel.MainViewModel vm = new ViewModel.MainViewModel();
        Server _server = new Server();
        public Form1()
        {
            InitializeComponent();
            vm.UsersChanged += OnUsersChanged;
            vm.MessagesChanged += OnMessagesChanged;
            UpdateActiveUsers();
            UpdateChat();
            button2.Enabled = false;
            

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {

            vm.ConnectToServerCommand.Execute(null);
            Thread.Sleep(1000);
            UpdateActiveUsers();
            



        }
        private void UpdateActiveUsers()
        {
            ActiveUsers.Text = "";
            vm.Users.ToList().ForEach(x => ActiveUsers.Text += x.Username + "\n");
        }
        private void usernameBoxChanged(object sender, EventArgs e)
        {

            button2.Enabled = !string.IsNullOrEmpty(usernameBox.Text);
            vm.Username = usernameBox.Text;
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            string message = MessageBox.Text;
            MessageBox.Text = "";

            vm.Message = message;
            vm.SendMessageToServerCommand.Execute(null);
            Thread.Sleep(1000);
            Console.WriteLine(message);
            UpdateChat();
       
            
        }
        private void UpdateChat()
        {
            Chat.Text = "";
            vm.Messages.ToList().ForEach(x => Chat.Text += x + "\n");
        }
        private void OnUsersChanged()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { UpdateActiveUsers(); });
            }
            else
            {
                UpdateActiveUsers();
            }
        }

        private void OnMessagesChanged()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { UpdateChat(); });
            }
            else
            {
                UpdateChat();
            }
        }


    }
}
