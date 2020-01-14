using Login.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.Common
{
    public class DealJsonData
    {

        public static string GetJsonStr(string str)
        {
            string message = "";
            if (str != "" & str != null)
            {
                string mESXPT_ModuleMiscInfo = JsonConvert.DeserializeObject<string>(str);
                if (mESXPT_ModuleMiscInfo != "" && mESXPT_ModuleMiscInfo != null)
                {
                    message = mESXPT_ModuleMiscInfo;
                }
            }
            return message; ;
        }

        /// <summary>
        /// 根据URL接收json字符串
        /// </summary>
        /// <param name="url"></param>
        /// <returns>返回Json字符串</returns>
        public static string GetJsonData(string url)
        {
            string urlNow = url;
            string JsonData = HttpUtils.Get("urlNow");
            return JsonData;
        }

        /// <summary>
        /// 根据URL获取json数据并解析为object
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static MESXPT_ModuleMiscInfo AnalysisJsonStr(string url)
        {
            string JsonStr= HttpUtils.Get("url");
            MESXPT_ModuleMiscInfo mESXPT_ModuleMiscInfo = JsonConvert.DeserializeObject<MESXPT_ModuleMiscInfo>(JsonStr);
            return mESXPT_ModuleMiscInfo;
        }



    }
}