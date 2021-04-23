using System;
using System.Collections.Generic;
using System.Text;

namespace ZXingSample
{
    class MemoraData
    {
        public static string _apiKey = "oFhhCXwJ0wcEPcAmx7yVbEkLy%2BvtBPSryqobF6EeR6kv8IolNjiuDsO8iGNM%2BUa6FjtY7rjE4VDRvkNToBmd%2FA%3D%3D";
        public static string _apiPrevKey = "oFhhCXwJ0wcEPcAmx7yVbEkLy%2BvtBPSryqobF6EeR6kv8IolNjiuDsO8iGNM%2BUa6FjtY7rjE4VDRvkNToBmd%2FA%3D%3D";

        public static string _GetLocCode(string strloc)
        {
            string result = "30200";

            switch (strloc)
            {
                case "대전_대덕구": result = "30230"; break;
                case "대전_동구": result = "30110"; break;
                case "대전_서구": result = "30170"; break;
                case "대전_유성구": result = "30200"; break;
                case "대전_중구": result = "30140"; break;
                case "천안_서북구": result = "44133"; break;
                case "천안_동남구": result = "44131"; break;
                case "평택시": result = "41220"; break;
                case "아산시": result = "44200"; break;
                case "세종시": result = "36110"; break;


                default: break;
            }
            return result;
        }
    }
}
