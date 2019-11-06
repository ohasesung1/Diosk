using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Diosk.Core;

namespace Diosk
{
    /// <summary>
    /// LoginWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : UserControl
    {
        serverClient client = new serverClient();
        public delegate void LoginCompleteHandler(Object sender, OrderArgs args);
        public event LoginCompleteHandler OnLoginComplete;

        public LoginWindow()
        {
            InitializeComponent();
        }

        public void SetLogoutTime(object sender, RoutedEventArgs e)
        {
            String LogoutTime = DateTime.Now.ToString("hh : mm : ss");
            logoutTime.Content = "  최종접속시간\n   " + LogoutTime;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            int isConneted = client.ConnectServer();
            if (isConneted == 0)
            {
                MessageBox.Show("서버 연결 실패!");
            }

            String Id = id.Text;
            int isSuccess = client.SendMessage(id.Text);
            if(isSuccess == 0)
            {
                MessageBox.Show("전송 실패!");
            }
            else if(Id.Equals("@2204") || Id.Equals("@2211") || Id.Equals("@2212"))
            {
                OnLoginComplete(this, null);
                id.Text = "";
                this.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("아이디가 틀렸습니다");
            }
        }
    }
}
