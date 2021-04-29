using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZXingSample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class APTTransInfo : ContentPage
	{
        private Dictionary<string, List<string>> list = new Dictionary<string, List<string>>();
        private Dictionary<string, string> codelist = new Dictionary<string, string>();
        private DataTable _dt;
        public APTTransInfo ()
		{
			InitializeComponent ();

            MemoraData.SetAptCode(ref codelist);

            _initControls();
		}

        private void _initControls()
        {
            DateTime now = DateTime.Now;
            cboYear.SelectedItem = now.Year.ToString();
            cboMonth.SelectedItem = now.Month.ToString().Length >= 2 ? now.Month.ToString() : "0" + now.Month.ToString();
        }
        private void _Addlist(string dong, string value)
        {
            if (!list.ContainsKey(dong))
                list.Add(dong, new List<string>() { value });
            else
                list[dong].Add(value);
        }
        private void _SetData(string xmlData)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlData);

            XmlNodeList xmlNodeheader = xml.GetElementsByTagName("header");
            string resultCode = xmlNodeheader.Item(0)["resultCode"].InnerText.Trim();

            string loc_cd = String.Empty;
            string sloc_cd = String.Empty;
            string dong = String.Empty;
            string apt = String.Empty;
            string makeyear = String.Empty;
            string scope = String.Empty;
            string floor = String.Empty;
            string money = String.Empty;
            string year = String.Empty;
            string month = String.Empty;
            string day = String.Empty;
            string iscancle = String.Empty;
            string cancleday = String.Empty;

            XmlNodeList xmlNodeList = xml.GetElementsByTagName("item");
            foreach (XmlNode xmlnode in xmlNodeList)
            {
                XmlNodeList childNodes = xmlnode.ChildNodes;
                foreach (XmlNode item in childNodes)
                {
                    switch (item.Name)
                    {
                        case "지역코드": loc_cd = item.InnerText.Trim(); break;
                        case "지번": sloc_cd = item.InnerText.Trim(); break;
                        case "법정동": dong = item.InnerText.Trim(); break;
                        case "아파트": apt = item.InnerText.Trim(); break;
                        case "건축년도": makeyear = item.InnerText.Trim(); break;
                        case "전용면적": scope = item.InnerText.Trim(); break;
                        case "층": floor = item.InnerText.Trim(); break;
                        case "거래금액": money = item.InnerText.Trim(); break;
                        case "년": year = item.InnerText.Trim(); break;
                        case "월": month = item.InnerText.Trim(); break;
                        case "일": day = item.InnerText.Trim(); break;
                        case "해제여부": iscancle = item.InnerText.Trim(); break;
                        case "해제사유발생일": cancleday = item.InnerText.Trim(); break;
                    }
                }
                _Addlist(dong, dong + "_" + apt + "(" + makeyear + "년)" + "_[" + money + "]_" + scope + "(" + floor + "층)_{" + month + "." + day + "}_" + cancleday + Environment.NewLine);
            }

            foreach (var item in list)
            {
                if (cboDong.Items.Contains(item.Key))
                    continue;

                cboDong.Items.Add(item.Key);
            }
        }
        private void _SetData2(string xmlData)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlData);

            XmlNodeList xmlNodeheader = xml.GetElementsByTagName("header");
            string resultCode = xmlNodeheader.Item(0)["resultCode"].InnerText.Trim();

            string loc_cd = String.Empty;
            string sloc_cd = String.Empty;
            string dong = String.Empty;
            string apt = String.Empty;
            string makeyear = String.Empty;
            string scope = String.Empty;
            string floor = String.Empty;
            string money = String.Empty;
            string year = String.Empty;
            string month = String.Empty;
            string day = String.Empty;
            string iscancle = String.Empty;
            string cancleday = String.Empty;

            XmlNodeList xmlNodeList = xml.GetElementsByTagName("item");
            foreach (XmlNode xmlnode in xmlNodeList)
            {
                XmlNodeList childNodes = xmlnode.ChildNodes;
                foreach (XmlNode item in childNodes)
                {
                    switch (item.Name)
                    {
                        case "지역코드": loc_cd = item.InnerText.Trim(); break;
                        case "지번": sloc_cd = item.InnerText.Trim(); break;
                        case "법정동": dong = item.InnerText.Trim(); break;
                        case "단지": apt = item.InnerText.Trim(); break;
                        case "건축년도": makeyear = item.InnerText.Trim(); break;
                        case "전용면적": scope = item.InnerText.Trim(); break;
                        case "층": floor = item.InnerText.Trim(); break;
                        case "거래금액": money = item.InnerText.Trim(); break;
                        case "년": year = item.InnerText.Trim(); break;
                        case "월": month = item.InnerText.Trim(); break;
                        case "일": day = item.InnerText.Trim(); break;
                        case "해제여부": iscancle = item.InnerText.Trim(); break;
                        case "해제사유발생일": cancleday = item.InnerText.Trim(); break;
                    }
                }
                _Addlist(dong, dong + "_" + apt + "(분양권)" + "_[" + money + "]_" + scope + "(" + floor + "층)_{" + month + "." + day + "}_" + cancleday + Environment.NewLine);
            }

            foreach (var item in list)
            {
                if (cboDong.Items.Contains(item.Key))
                    continue;

                cboDong.Items.Add(item.Key);
            }
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
                textBox1.Text = String.Empty;
                list.Clear();
                cboDong.Items.Clear();
                cboApt.Items.Clear();
                cboDong.SelectedItem = null;
                cboApt.SelectedItem = null;

                string loc = cboloc.SelectedItem.ToString().Trim();
                if (String.IsNullOrEmpty(loc))
                    return;

                // 44133 서북구
                // 44131 동남구
                // 30170 둔산동
                string code = MemoraData._GetLocCode(loc);
                string date = cboYear.SelectedItem.ToString().Trim() + cboMonth.SelectedItem.ToString().Trim();
                if (String.IsNullOrEmpty(date))
                    return;

                string xmlData = HttpCommunicator.GetAPTInfo(code, date);
                _SetData(xmlData);

                xmlData = HttpCommunicator.GetPrevAPTInfo(code, date);
                _SetData2(xmlData);

            }
            catch (Exception ex)
            {
                DisplayAlert("", ex.Message, "확인");
            }
        }
        private void BtnSearch2_Clicked(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = String.Empty;
                string loc = cboloc.SelectedItem.ToString().Trim();
                if (String.IsNullOrEmpty(loc))
                    return;

                string dong = cboDong.SelectedItem.ToString().Trim();
                if (String.IsNullOrEmpty(dong))
                    return;

                string apt = cboApt.SelectedItem.ToString().Trim();
                if (String.IsNullOrEmpty(apt))
                    return;

                string code = String.Empty;
                //code = MemoraData.GetAptCode(apt, codelist);
                code = HttpCommunicator.GetAPTCode(apt);
                JObject a = JObject.Parse(code);
                if (a["AccessSts"].ToString().Trim() == String.Empty)
                {
                    DisplayAlert("", "코드정보가 없습니다.", "확인");
                    return;
                }
                else
                {
                    code = a["AccessSts"].ToString().Trim();
                }

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

                        //string text = "[" + _price + "]_" + _spec + "(" + _dong + _flr.Split(new char[] { '/' })[0] + "층)_{" + _indate + "}";
                        //text += Environment.NewLine;
                        //textBox2.Text += text;
                    }
                }

                DataView dtv = _dt.DefaultView;
                dtv.Sort = "PRICE";
                _dt = dtv.ToTable();

                foreach (DataRow item in _dt.Rows)
                {
                    string text = "[" + item[0].ToString().Trim() + "]_" + item[1].ToString().Trim();
                    text += Environment.NewLine;
                    textBox2.Text += text;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("", ex.Message, "확인");
            }
        }
        private void CboDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDong.SelectedItem == null)
                return;

            cboApt.Items.Clear();
            cboApt.SelectedItem = null;
            cboApt.SelectedItem = null;
            List<string> aptlist = new List<string>();
            string dong = cboDong.SelectedItem.ToString().Trim();
            foreach (var item in list)
            {
                if (item.Key == dong)
                {
                    foreach (var subitem in item.Value)
                    {
                        if (!aptlist.Contains(subitem.ToString().Split(new char[] { '_' })[1]))
                            aptlist.Add(subitem.ToString().Split(new char[] { '_' })[1]);
                    }

                }
            }

            foreach (var item in aptlist)
                cboApt.Items.Add(item);
        }
        private void CboApt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboApt.SelectedItem == null)
            {
                this.textBox1.Text = String.Empty;
                return;
            }

            string dong = cboDong.SelectedItem.ToString().Trim();
            string apt = cboApt.SelectedItem.ToString().Trim();
            this.textBox1.Text = String.Empty;

            foreach (var item in list)
            {
                if (item.Key == dong)
                {
                    foreach (var subitem in item.Value)
                    {
                        string capt = subitem.ToString().Split(new char[] { '_' })[1];
                        if (apt == capt)
                        {
                            //textBox1.Text += subitem;
                            string[] values = subitem.Split(new char[] { '_' });
                            string result = string.Empty;
                            int j = 1;
                            for(int i =2; i < values.Length;i++)
                            {
                                j++;
                                if(j >= values.Length - 1)
                                    result += values[i];
                                else
                                    result += values[i] + "_";
                            }
                            textBox1.Text += result;
                        }
                    }
                }
            }
        }
        private void TextBox1_Focused(object sender, FocusEventArgs e)
        {
            textBox1.Unfocus();
        }
        private void TextBox2_Focused(object sender, FocusEventArgs e)
        {
            textBox2.Unfocus();
        }
    }
}