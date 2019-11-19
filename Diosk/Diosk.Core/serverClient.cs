using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Diosk.Core
{
    public class ServerArgs : EventArgs
    {
        public string Message { get; set; }
    }
    public class serverClient
    {
        public delegate void ServerClosedHandler(Object sender, ServerArgs args);
        public event ServerClosedHandler ServerClosed;

        public Byte[] RecvBuffer = new Byte[100];
        private Socket workingSocket = null;

        public int ConnectServer()
        {
            workingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            Boolean isConnected = false;

            try
            {
                workingSocket.Connect("10.80.163.138", 80);
                isConnected = true;
            }
            catch (Exception ex)
            {
                isConnected = false;
                Console.WriteLine(ex.Message);
            }

            if(isConnected)
            {
                workingSocket.BeginReceive(RecvBuffer, 0, RecvBuffer.Length, SocketFlags.None, ReceiveMessageCallback, null);
                Console.WriteLine("연결 성공!");
                return 1;
            }
            else
            {
                Console.WriteLine("연결 실패!");
                return 0;
            }
        }

        public void SendMessage(String message)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                workingSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, null, null);
            }
            catch(Exception ex)
            {
                Console.WriteLine("메세지 전송중 오류 발생!", ex.Message);

                ServerArgs args = new ServerArgs();
                args.Message = "메세지 전송 오류";

                ServerClosed(this, args);
            }
        }

        public void ReceiveMessageCallback(IAsyncResult ar)
        {
            int received;

            try
            {
                received = workingSocket.EndReceive(ar);

                if (received > 0)
                {
                    byte[] recBuf = new byte[received];
                    Array.Copy(RecvBuffer, recBuf, received);

                    Console.WriteLine("메세지 받음: {0}", Encoding.UTF8.GetString(recBuf));
                    workingSocket.BeginReceive(RecvBuffer, 0, RecvBuffer.Length, SocketFlags.None, ReceiveMessageCallback, null);
                }
                else
                {
                    Console.WriteLine("서버 연결 끊김");

                    ServerArgs args = new ServerArgs();
                    args.Message = "서버 연결 끊음";
                    ServerClosed(this, args);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("자료 수신 대기 도중 오류 발생! 메세지: {0}", ex.Message);
                return;
            }
        }

        public void Socket_Close()
        {
            workingSocket.Close();
        }
    }
}
