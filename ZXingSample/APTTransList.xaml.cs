using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZXingSample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class APTTransList : ContentPage
	{
        private DataTable _dt;

        public APTTransList ()
		{
			InitializeComponent ();

            _InitControls();
		}

        private void _InitControls()
        {
            APTModel models = new APTModel();
            models.AddItem("천안역사동아라이크텐(아)", "118333");
            models.AddItem("천안역사동아라이크텐(오)", "118334");
            models.AddItem("백석마을아이파크", "26134");
            models.AddItem("백석리슈빌", "26768");
            models.AddItem("천안백석푸르지오", "26689");

            models.AddItem("e편한세상두정2차", "103358");
            models.AddItem("두정역효성해링턴플레이스", "117453");
            models.AddItem("포레나천안두정", "127119");

            models.AddItem("천안시티자이", "111858");
            models.AddItem("천안스마일시티효성해링턴플레이스", "107453");
            models.AddItem("e편한세상스마일시티", "106311");
            models.AddItem("e편한세상스마일시티2차", "108810");
            models.AddItem("천안한화꿈에그린스마일시티", "105337");

            models.AddItem("대동다숲", "10451");
            models.AddItem("동일하이빌", "10124");
            models.AddItem("대원칸타빌", "10551");
            
            models.AddItem("호반리젠시빌스위트", "10720");
            models.AddItem("불당리더힐스", "109247");

            models.AddItem("힐스테이트천안", "121930");
            models.AddItem("신천안한성필하우스에듀타운1단지", "126749");
            models.AddItem("신천안한성필하우스에듀타운2단지", "126678");

            models.AddItem("버들마을우미린", "26943");
            models.AddItem("천안청수한양수자인", "26891");
            models.AddItem("행정타운센트럴두산위브", "134767");
            models.AddItem("천안청당서희스타힐스", "129755");
            models.AddItem("청당코오롱하늘채", "116435");
            models.AddItem("천안청당서희스타힐스", "129755");
            
            models.AddItem("아산탕정2-A2신혼희망타운", "129504");
            models.AddItem("연화마을STX칸6단지", "27115");
            models.AddItem("더샵센트로", "140484");
            

            models.AddItem("크로바", "5986");
            models.AddItem("목련", "5962");
            models.AddItem("가람", "5800");
            
            models.AddItem("청솔", "24922");
            models.AddItem("국화동성", "5801");
            models.AddItem("국화라이프", "5802");
            models.AddItem("국화신동아", "5803");
            models.AddItem("국화우성", "5804");
            models.AddItem("국화한신", "5806");
            models.AddItem("e편한세상대전에코포레", "120741");

            models.AddItem("평택뉴비전엘크루", "125255");
            //models.AddItem("천안백석아이파크2차", "105354");
            //models.AddItem("백석더샵", "108523");
            //models.AddItem("두정역코아루스위트", "106845");
            //models.AddItem("이편한세상-천안두정2차", "103358");
            //models.AddItem("두정역이안더센트럴", "27180");
            //models.AddItem("천안두정역푸르지오", "26322");
            //models.AddItem("천안레이크타운2차푸르지오", "110557");
            //models.AddItem("천안레이크타운푸르지오", "109293");
            //models.AddItem("천안푸르지오레이크사이드", "134126");
            //models.AddItem("불당아이파크", "25557");
            ////models.AddItem("불당한화꿈에그린", "26270");
            //models.AddItem("천안불당지웰시티푸르지오2단지", "110597");
            //models.AddItem("불당리더힐스", "109247");
            //models.AddItem("천안불당린스트라우스2단지", "109536");
            //models.AddItem("불당파크푸르지오1단지", "111408");
            //models.AddItem("불당파크푸르지오2단지", "111452");
            //models.AddItem("버들마을우미린", "26943");
            //models.AddItem("힐스테이트천안신부", "110256");
            //models.AddItem("신부동도솔노블시티동문굿모닝힐", "109735");
            //models.AddItem("탕정지구시티프라디움", "125259");
            //models.AddItem("탕정지구지웰시티푸르지오2차", "127809");
            //models.AddItem("탕정지구지웰시티푸르지오(2-C1BL)", "125132");
            //models.AddItem("연화마을STX칸6단지", "27115");
            //models.AddItem("연화마을휴먼시아8단지", "26808");
            //models.AddItem("장재마을휴먼시아11단지", "27139");

            cboDong.BindingContext = models;
        }
        private DataTable _MakeDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("PRICE", typeof(String)));
            dt.Columns.Add(new DataColumn("CMT", typeof(String)));
            return dt;
        }

        private void BtnSearch_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (cboDong.SelectedItem == null)
                    return;

                textBox1.Text = String.Empty;
                string code = ((KeyValuePair<string, string>)cboDong.SelectedItem).Key;

                if (_dt == null)
                    _dt = _MakeDataTable();
                else
                    _dt.Rows.Clear();

                string url = String.Empty;
                for (int i = 1; i < 100; i++)
                {
                    url = String.Format("https://m.land.naver.com/complex/getComplexArticleList?hscpNo={0}&tradTpCd=A1%3AB1%3AB2&order=point_&showR0=N&page={1}", code, i);
                    string aaa = HttpCommunicator.GetAPTSellInfo(url);

                    JObject jo = JObject.Parse(aaa);
                    JObject _info = (JObject)jo["result"];
                    JArray _list = (JArray)_info["list"];

                    if (_list.Count == 0)
                        break;

                    DataRow adr;
                    foreach (JToken item in _list)
                    {
                        if (item["tradTpNm"].ToString() != "매매")
                            continue;

                        adr = _dt.NewRow();
                        string _apt = item["atclNm"].ToString();
                        string _dong = item["bildNm"].ToString();
                        //string _spec = item["spc2"].ToString() + "/" + item["spc1"].ToString();
                        string _spec = item["spc2"].ToString();
                        string _flr = item["flrInfo"].ToString();
                        string _indate = item["cfmYmd"].ToString();
                        string _price = item["prcInfo"].ToString();

                        adr[0] = _price;
                        adr[1] = _spec + "(" + _dong + _flr.Split(new char[] { '/' })[0] + "층)_{" + _indate + "}";
                        _dt.Rows.Add(adr);
                    }
                }

                DataView dtv = _dt.DefaultView;
                dtv.Sort = "PRICE";
                _dt = dtv.ToTable();

                foreach (DataRow item in _dt.Rows)
                {
                    string text = "[" + item[0].ToString().Trim() + "]_" + item[1].ToString().Trim();
                    text += Environment.NewLine;
                    textBox1.Text += text;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("", ex.Message, "확인");
            }
        }
        private void TextBox1_Focused(object sender, FocusEventArgs e)
        {
            textBox1.Unfocus();
        }
    }
}