using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Web;

namespace Login.HttpUtil
{
    public class HttpHelp
    {
        private  string strInfo = "";//链接对象的信息
        private  string ipPort = "";//获取客户端ip地址
        private  string FromClientMst = "";//获取接受的数据
        private  string ExMessage = "";
        private  string FlagMes = "";//标志信息
        List<Socket> sockets = new List<Socket>();

        public void Listen()
        {
            //寻址协议、设置数据传输方式（流）、设置通信协议（Tcp）
            Socket serversocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定IP地址
            string strIp = "192.168.0.84";
           // string strIp = "172.16.100.150";
            //端口号
            int ports = 8200;

            IPAddress ip = IPAddress.Parse(strIp);
            IPEndPoint ipEndpoint = new IPEndPoint(ip, ports);
            try
            {
                FlagMes = "进入try";
                serversocket.Bind(ipEndpoint);
                serversocket.Listen(10);//开始监听******************* 
                FlagMes = "开始监听数据";
                //开始接受客户端的链接
                FlagMes = "开始接受客户端";
                ThreadPool.QueueUserWorkItem(new WaitCallback(StartAccetpClient), serversocket);
            }
            catch(Exception ex)
            {
                ExMessage = "监听数据异常！！！！！";
            }
           
            
        }


        /// <summary>
        /// 获取标志信息
        /// </summary>
        /// <returns></returns>
        public  string GetFlag()
        {
            return FlagMes;
        }


        /// <summary>
        /// 获取链接对象
        /// </summary>
        /// <returns></returns>
        public  string GetConnObj()
        {
            return strInfo;
        }

        /// <summary>
        /// 获取ip
        /// </summary>
        /// <returns></returns>
        public  string GetIp()
        {
            return ipPort;
        }

        /// <summary>
        /// 获取所接收的数据
        /// </summary>
        /// <returns></returns>
        public  string GetReciveData()
        {
            return FromClientMst;
        }


        /// <summary>
        /// 获取异常数据
        /// </summary>
        /// <returns></returns>

        public  string GetExMessage()
        {
            return ExMessage;
        }

        private void StartAccetpClient(object state)
        {
            // List<string,string> disSocket = new List<string,string>();
            Dictionary<string, Socket> disSocket = new Dictionary<string, Socket>();
            
            var serverSocket = (Socket)state;
            FlagMes = "服务器接受客户端的连接";
            //服务器开始接受客户端的链接******************
            while (true)
            {
                try
                {
                    Socket prosock = serverSocket.Accept();
                    //将远程链接的客户端的IP地址和socket存入集合中
                    disSocket.Add(prosock.RemoteEndPoint.ToString(),prosock);
                    FlagMes = "成功将远程客户端的ip地址和socket存入集合中";
                    //获取客户端ip地址
                    ipPort = prosock.RemoteEndPoint.ToString();
                    // MedicineDevice ns =
                    FlagMes = "成功获取ip地址";
                    //链接对象的信息
                    strInfo = prosock.RemoteEndPoint.ToString();
                    sockets.Add(prosock);

                    //服务器接受客户端的消息
                    FlagMes = "将开始接受客户端的数据";
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.RecceveData),prosock);

                }
                catch(Exception e)
                {
                    ExMessage = "接受客户异常！！！！！";
                    return;
                }
            }
        }

       
        private void RecceveData(object obj)
        {
            var prosock = (Socket)obj;
            byte[] data = new byte[1024*1024];
            while(true)
            {
                int realen = 0;
                try
                {
                    realen = prosock.Receive(data,0,data.Length,SocketFlags.None);
                }
                catch(Exception e)
                {
                    //异常退出
                    ExMessage = string.Format("设备 {0} 异常退出", prosock.RemoteEndPoint.ToString());
                    ExMessage = "接受数据异常，即将退出！！！！！";
                    StopConnect(prosock);
                    return;

                }
                if(realen<=0)
                {
                    ExMessage = string.Format("设备 {0} 正常退出", prosock.RemoteEndPoint.ToString());
                    prosock.Shutdown(SocketShutdown.Both);
                    prosock.Close();
                    sockets.Remove(prosock);
                    return;
                }
                //接受到的数据
                FromClientMst = Encoding.Default.GetString(data,0,realen);
            }
        }

        private void StopConnect(Socket prosock)
        {
            try
            {
                if(prosock.Connected)
                {
                    prosock.Shutdown(SocketShutdown.Both);
                    prosock.Close(100);
                }
            }
            catch(Exception ex)
            {
                ExMessage = string.Format("设备 {0} 关闭链接异常", prosock.RemoteEndPoint.ToString());
            }
        }
    }
}