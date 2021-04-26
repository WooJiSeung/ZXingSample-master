using System;
using System.Collections.Generic;
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

        public APTTransInfo ()
		{
			InitializeComponent ();

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
    }
}