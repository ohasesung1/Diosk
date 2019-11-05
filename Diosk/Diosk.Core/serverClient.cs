﻿using System;
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
        public Byte[] RecvBuffer = new Byte[100];
        private Socket workingSocket = null;

        public int ConnectServer()
        {
            workingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            Boolean isConnected = false;
            try
            {
                workingSocket.Connect("10.80.162.116", 8000);
                isConnected = true;
            }
            catch (Exception ex)
            {
                isConnected = false;
                Console.WriteLine(ex.Message);
            }

            if(isConnected)
            {
                ReceiveCallback(workingSocket);
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
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                workingSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, null, null);
                ReceiveCallback(workingSocket);
                Console.WriteLine("전송 성공");
                return 1;
            }
            catch(Exception ex)
            {
                Console.WriteLine("메세지 전송중 오류 발생!", ex.Message);
                return 0;
            }
        }

        public void ReceiveCallback(Socket client)
        {
            try
            {
                client.BeginReceive(RecvBuffer, 0, RecvBuffer.Length, 0, new AsyncCallback(handleDataReceive), client);
                Console.WriteLine(RecvBuffer);
            }
            catch (Exception e)
            {
                Console.WriteLine("리시브 에러!", e.ToString());
            }
        }

        public void handleDataReceive(IAsyncResult ar)
        {
            int received;

            try
            {
                received = workingSocket.EndReceive(ar);
            }
            catch
            {
                return;
            }

            if (received > 0)
            {
                byte[] recBuf = new byte[received];
                Array.Copy(RecvBuffer, recBuf, received);

                Console.WriteLine("메세지 받음: {0}", Encoding.UTF8.GetString(recBuf));
            }

            try
            {
                workingSocket.BeginReceive(RecvBuffer, 0, RecvBuffer.Length, SocketFlags.None, null, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("자료 수신 대기 도중 오류 발생! 메세지: {0}", ex.Message);
                return;
            }
        }
    }
}
