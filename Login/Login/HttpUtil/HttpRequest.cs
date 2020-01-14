using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Web;

namespace Login.HttpUtil
{
    public class HttpRequestSelf
    {
        private static int MAX_POST_SIZE = 10 * 1024 * 1024;
        private const int BUF_SIZE = 4096;
        private byte[] buf = new byte[BUF_SIZE];
        public string Method = "";
        public string URL = "";
        public string httpProtocol = "";
        private NetworkStream InStream = null;
        public Dictionary<string, string> Params = new Dictionary<string, string>();
        public HttpRequestSelf(NetworkStream InStream)
        {
            this.InStream = InStream;
        }
        private string streamReadLine(Stream inputStream)
        {
            int next_char;
            string data = "";
            while (true)
            {
                next_char = inputStream.ReadByte();
                if (next_char == '\n')
                {
                    break;
                }
                if (next_char == '\r')
                {
                    continue;
                }
                if (next_char == -1)
                {
                    Thread.Sleep(1);
                    continue;
                };
                data += Convert.ToChar(next_char);
            }
            return data;
        }
        //获取URL
        public string GetUrl()
        {
            //读取网络基础数据流数据
            string URL = streamReadLine(InStream);
            //将获取的URL字符串拆分成多个子字符串
            string[] tokens = URL.Split(' ');
            //判断字符串的长度是否是3个
            if (tokens.Length != 3)
            {
                throw new Exception("invalid http request line");
            }
            //将0位置字符串转换成大写
            this.Method = tokens[0].ToUpper();
            //提取URL
            this.URL = tokens[1];
            //提取http协议
            this.httpProtocol = tokens[2];
            return this.URL;
        }

        //获取报文头部信息
        public void GetHeaders()
        {
            Params.Clear();
            string line;
            while ((line = streamReadLine(InStream)) != null)
            {
                if (line.Equals(""))
                {
                    return;
                }

                // 摘要:
                //     报告指定 Unicode 字符在此字符串中的第一个匹配项的从零开始的索引。
                //
                // 参数:
                //   value:
                //     要查找的 Unicode 字符。
                //
                // 返回结果:
                //     如果找到该字符，则为 value 的从零开始的索引位置；如果未找到，则为 -1。
                int separator = line.IndexOf(':');
                if (separator == -1)
                {
                    throw new Exception("invalid http header line: " + line);
                }
                String name = line.Substring(0, separator);
                int pos = separator + 1;
                while ((pos < line.Length) && (line[pos] == ' '))
                {
                    pos++;
                }
                string value = line.Substring(pos, line.Length - pos);
                Params.Add(name, value);
            }
        }

        //获取信息
        /// <summary>
        /// 获取测试端的数据数据
        /// </summary>
        public void GetMessage()
        {
            if (this.Params.ContainsKey("Content-Length"))
            {

                StringBuilder myCompleteMessage = new StringBuilder();
                int to_read = Convert.ToInt32(this.Params["Content-Length"]);
                if (to_read > MAX_POST_SIZE)//大于10M
                {
                    throw new Exception(String.Format("POST Content-Length({0}) too big for this simple server", to_read));
                }
                while (to_read > 0)
                {
                    int numread = this.InStream.Read(buf, 0, Math.Min(BUF_SIZE, to_read));
                    if (numread == 0)
                    {
                        if (to_read == 0)
                        {
                            break;
                        }
                        else
                        {
                            throw new Exception("client disconnected during post");
                        }
                    }
                    to_read -= numread;
                    myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(buf, 0, numread));
                }
                Params.Add("message", myCompleteMessage.ToString());
            }
        }
        
        ~HttpRequestSelf()
        {
            Params.Clear();
            Params = null;
            buf = null;
            InStream = null;
        }
    }


}