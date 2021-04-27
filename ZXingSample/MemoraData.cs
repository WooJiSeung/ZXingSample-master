using System;
using System.Collections.Generic;
using System.Linq;
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
        public static void SetAptCode(ref Dictionary<string, string> codelist)
        {
            codelist.Add("천안역사동아라이크텐(아)", "118333");
            codelist.Add("천안역사동아라이크텐(오)", "118334");
            codelist.Add("천안백석아이파크2차", "105354");
            codelist.Add("백석마을아이파크", "26134");
            codelist.Add("백석더샵", "108523");
            codelist.Add("백석리슈빌", "26768");
            codelist.Add("두정역코아루스위트", "106845");
            codelist.Add("이편한세상-천안두정2차", "103358");
            codelist.Add("두정역이안더센트럴", "27180");
            codelist.Add("두정역효성해링턴플레이스", "117453");
            codelist.Add("천안두정역푸르지오", "26322");
            codelist.Add("포레나천안두정", "127119");
            codelist.Add("천안백석푸르지오", "26689");
            codelist.Add("천안시티자이", "111858");
            codelist.Add("천안레이크타운2차푸르지오", "110557");
            codelist.Add("천안레이크타운푸르지오", "109293");
            codelist.Add("천안푸르지오레이크사이드", "134126");
            codelist.Add("천안스마일시티효성해링턴플레이스", "107453");
            codelist.Add("e편한세상스마일시티", "106311");
            codelist.Add("e편한세상스마일시티2차", "108810");
            codelist.Add("천안한화꿈에그린스마일시티", "105337");
            codelist.Add("대동다숲", "10451");
            codelist.Add("동일하이빌", "10124");
            codelist.Add("불당아이파크", "25557");
            codelist.Add("불당한화꿈에그린", "26270");
            codelist.Add("천안불당지웰시티푸르지오2단지", "110597");
            codelist.Add("호반리젠시빌스위트", "10720");
            codelist.Add("불당리더힐스", "109247");
            codelist.Add("천안불당린스트라우스2단지", "109536");
            codelist.Add("불당파크푸르지오1단지", "111408");
            codelist.Add("불당파크푸르지오2단지", "111452");
            codelist.Add("힐스테이트천안", "121930"); 
            codelist.Add("신천안한성필하우스에듀타운1단지", "126749");
            codelist.Add("신천안한성필하우스에듀타운2단지", "126678");
            codelist.Add("버들마을우미린", "26943");
            codelist.Add("천안청수한양수자인", "26891");
            codelist.Add("행정타운센트럴두산위브", "134767");
            codelist.Add("천안청당서희스타힐스", "129755");
            codelist.Add("힐스테이트천안신부", "110256");
            codelist.Add("신부동도솔노블시티동문굿모닝힐", "109735");
            codelist.Add("아산탕정2-A2신혼희망타운", "129504");


            codelist.Add("탕정지구시티프라디움", "125259");
            codelist.Add("탕정지구지웰시티푸르지오2차", "127809");
            codelist.Add("탕정지구지웰시티푸르지오(2-C1BL)", "125132");
            codelist.Add("연화마을STX칸6단지", "27115");
            codelist.Add("연화마을휴먼시아8단지", "26808");
            codelist.Add("장재마을휴먼시아11단지", "27139");
            //codelist.Add("아산탕정2-A2블록신혼희망타운", "129504");
            //codelist.Add("아산탕정2-A2블록신혼희망타운", "129504");
            //codelist.Add("아산탕정2-A2블록신혼희망타운", "129504");
            //codelist.Add("아산탕정2-A2블록신혼희망타운", "129504");
            //codelist.Add("아산탕정2-A2블록신혼희망타운", "129504");


        }
        public static string GetAptCode(string apt, Dictionary<string, string> codelist)
        {
            string aptName = apt.Split(new char[] { '(' })[0];
            aptName = string.Concat(aptName.Where(x => !char.IsWhiteSpace(x)));

            string result = String.Empty;
            foreach (var item in codelist)
            {
                if (item.Key.Contains(aptName))
                    result = item.Value;
            }

            if (result == String.Empty)
            {
                foreach (var item in codelist)
                {
                    if (aptName.Contains(item.Key))
                        result = item.Value;
                }
            }

            return result;
        }
    }
}
