using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Diosk.Core
{
    class serverClient
    {
        public class AsyncObject
        {
            public Byte[] Buffer;
            public Socket WorkingSocket;
            public AsyncObject(Int32 bufferSize)
            {
                this.Buffer = new Byte[bufferSize];
            }
        }

        private Boolean g_Connected;
        private Socket m_ClientSocket = null;
        private AsyncCallback m_fnReceiveHandler;
        private AsyncCallback m_fnSendHandler;

        public void ConnectServer()
        {
            m_ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            Boolean isConnected = false;
            try
            {
                m_ClientSocket.Connect("10.80.162.116", 6000);
                isConnected = true;
            }
            catch (Exception ex)
            {
                isConnected = false;
            }

            g_Connected = isConnected;

            if(isConnected)
            {
                AsyncObject ao = new AsyncObject(1);
                ao.WorkingSocket = m_ClientSocket;

                m_ClientSocket.BeginReceive(ao.Buffer, 0, ao.Buffer.Length, SocketFlags.None, m_fnReceiveHandler, ao);
                Console.WriteLine("연결 성공!");
            }
            else
            {
                Console.WriteLine("연결 실패!");
            }
        }

        public void SendMessage(String message)
        {
            AsyncObject ao = new AsyncObject(1);

            ao.Buffer = Encoding.UTF8.GetBytes(message);
            ao.WorkingSocket = m_ClientSocket;

            try
            {
                m_ClientSocket.BeginSend(ao.Buffer, 0, ao.Buffer.Length, SocketFlags.None, m_fnSendHandler, ao);
                Console.WriteLine("전송 성공");
            }
            catch(Exception ex)
            {
                Console.WriteLine("메세지 전송중 오류 발생!", ex.Message);
            }
        }

        public void handleDataReceive(IAsyncResult ar)
        {
            AsyncObject ao = (AsyncObject)ar.AsyncState;
            Int32 recvBytes;

            try
            {
                recvBytes = ao.WorkingSocket.EndReceive(ar);
            }
            catch
            {
                return;
            }

            if (recvBytes > 0)
            {
                Byte[] msgByte = new Byte[recvBytes];
                Array.Copy(ao.Buffer, msgByte, recvBytes);

                Console.WriteLine("메세지 받음: {0}", Encoding.Unicode.GetString(msgByte));
            }

            try
            {
                ao.WorkingSocket.BeginReceive(ao.Buffer, 0, ao.Buffer.Length, SocketFlags.None, m_fnReceiveHandler, ao);
            }
            catch (Exception ex)
            {
                Console.WriteLine("자료 수신 대기 도중 오류 발생! 메세지: {0}", ex.Message);
                return;
            }
        }

    }
}
