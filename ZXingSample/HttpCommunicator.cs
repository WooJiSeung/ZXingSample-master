﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ZXingSample
{
    public class HttpCommunicator
    {
        public static string GetAPTInfo(string LAWD_CD, string DEAL_YMD)
        {
            string url = "http://openapi.molit.go.kr:8081/OpenAPI_ToolInstallPackage/service/rest/RTMSOBJSvc/getRTMSDataSvcAptTrade"; // URL
            url += "?ServiceKey=" + MemoraData._apiKey; // Service Key
            url += "&LAWD_CD=" + LAWD_CD;
            url += "&DEAL_YMD=" + DEAL_YMD;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            string results = string.Empty;
            HttpWebResponse response;
            using (response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }

            request.Abort();
            return results;
        }
        public static string GetPrevAPTInfo(string LAWD_CD, string DEAL_YMD)
        {
            string url = "http://openapi.molit.go.kr/OpenAPI_ToolInstallPackage/service/rest/RTMSOBJSvc/getRTMSDataSvcSilvTrade"; // URL
            url += "?ServiceKey=" + MemoraData._apiPrevKey; // Service Key
            url += "&LAWD_CD=" + LAWD_CD;
            url += "&DEAL_YMD=" + DEAL_YMD;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            string results = string.Empty;
            HttpWebResponse response;
            using (response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }

            request.Abort();
            return results;
        }
        public static string GetAPTSellInfo(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            string results = string.Empty;
            HttpWebResponse response;
            using (response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }

            request.Abort();
            return results;
        }
        public static string GetAPTLIST()
        {
            string url = "http://z.nifcokorea.com/SpearPDA/ERP.aspx?Code=GETAPTLIST";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            string results = string.Empty;
            HttpWebResponse response;
            using (response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }

            request.Abort();
            return results;
        }
        public static string GetAPTCode(string aptname)
        {
            string aptName = aptname.Split(new char[] { '(' })[0];
            aptName = string.Concat(aptName.Where(x => !char.IsWhiteSpace(x)));

            string url = "http://z.nifcokorea.com/SpearPDA/ERP.aspx?Code=GETAPTCODE&param=";
            url += aptName;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            string results = string.Empty;
            HttpWebResponse response;
            using (response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }

            request.Abort();
            return results;
        }
    }
}
