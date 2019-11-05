using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Diosk.Core
{
    public class serverClient
    {
        public class clientObject
        {
            public Byte[] Buffer;
            public Socket WorkingSocket;
            public clientObject(Int32 bufferSize)
            {
                this.Buffer = new Byte[bufferSize];
            }
        }

        //private Boolean g_Connected;
        private Socket m_ClientSocket = null;
        private AsyncCallback m_fnReceiveHandler;
        private AsyncCallback m_fnSendHandler;

        public int ConnectServer()
        {
            m_ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            Boolean isConnected = false;
            try
            {
                m_ClientSocket.Connect("10.80.162.116", 8080);
                isConnected = true;
            }
            catch (Exception ex)
            {
                isConnected = false;
            }

            //g_Connected = isConnected;

            if(isConnected)
            {
                clientObject co = new clientObject(1);
                co.WorkingSocket = m_ClientSocket;

                m_ClientSocket.BeginReceive(co.Buffer, 0, co.Buffer.Length, SocketFlags.None, m_fnReceiveHandler, co);
                Receive(co.WorkingSocket);
                Console.WriteLine("연결 성공!");
                return 1;
            }
            else
            {
                Console.WriteLine("연결 실패!");
                return 0;
            }
        }

        public int SendMessage(String message)
        {
            clientObject co = new clientObject(1);

            co.Buffer = Encoding.UTF8.GetBytes(message);
            co.WorkingSocket = m_ClientSocket;

            try
            {
                m_ClientSocket.BeginSend(co.Buffer, 0, co.Buffer.Length, SocketFlags.None, m_fnSendHandler, co);
                Receive(co.WorkingSocket);
                Console.WriteLine("전송 성공");
                return 1;
            }
            catch(Exception ex)
            {
                Console.WriteLine("메세지 전송중 오류 발생!", ex.Message);
                return 0;
            }
        }

        public void Receive(Socket client)
        {
            try
            {
                clientObject co = new clientObject(1);
                co.WorkingSocket = client;

                client.BeginReceive(co.Buffer, 0, co.Buffer.Length, 0, new AsyncCallback(handleDataReceive), co);
            }
            catch (Exception e)
            {
                Console.WriteLine("리시브 에러!", e.ToString());
            }
        }

        public void handleDataReceive(IAsyncResult ar)
        {
            clientObject co = (clientObject)ar.AsyncState;
            Int32 recvBytes;

            try
            {
                recvBytes = co.WorkingSocket.EndReceive(ar);
            }
            catch
            {
                return;
            }

            if (recvBytes > 0)
            {
                Byte[] msgByte = new Byte[recvBytes];
                Array.Copy(co.Buffer, msgByte, recvBytes);

                Console.WriteLine("메세지 받음: {0}", Encoding.Unicode.GetString(msgByte));
            }

            try
            {
                co.WorkingSocket.BeginReceive(co.Buffer, 0, co.Buffer.Length, SocketFlags.None, m_fnReceiveHandler, co);
            }
            catch (Exception ex)
            {
                Console.WriteLine("자료 수신 대기 도중 오류 발생! 메세지: {0}", ex.Message);
                return;
            }
        }
    }
}
