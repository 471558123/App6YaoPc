
using App6Yao.Models;
using Newtonsoft.Json;
using System.Reflection.Metadata;
namespace App6Yao { 
[QueryProperty(nameof(GuJson), "gujson")]
[QueryProperty(nameof(ReqJson), "reqjson")]
public partial class ShowPage : ContentPage
{
        ReqEntity Req;
        string yaoci = "";
        string tdyaoci = "";


        public string GuJson
        {

            set { LoadShow(value); }

        }
        public string ReqJson
        {
            get; set;

        }
        // Post请求
        public async Task<string> PostResponse(string postData, string url)
        {
            string result = string.Empty;
            //设置Http的正文
            HttpContent httpContent = new StringContent(postData);
            //设置Http的内容标头
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //设置Http的内容标头的字符
            httpContent.Headers.ContentType.CharSet = "utf-8";

            result = await HttpClientHelper.GetResponseByPost(httpContent, url);

            //using (HttpClient httpClient = HttpClientHelper.HttpClient)
            //{



            //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Views.HomePage.tockenStr);
            //    //异步Post
            //    HttpResponseMessage response = await httpClient.PostAsync(url, httpContent);//改成自己的
            //                                                                                //输出Http响应状态码
            //    string statusCode = response.StatusCode.ToString();
            //    //确保Http响应成功
            //    if (response.IsSuccessStatusCode)
            //    {
            //        //异步读取json
            //        result = response.Content.ReadAsStringAsync().Result;
            //    }
            //}






            return result;
        }
        private async void LoadShow(string postStr)
        {
            string result = await PostResponse(postStr, BaseEntity.url + "/api/Gua/YaoGua");



            GuaViewEntity obj = JsonConvert.DeserializeObject<GuaViewEntity>(result);

            Req = JsonConvert.DeserializeObject<ReqEntity>(postStr);



            Title = Req.inpzs;
            Szhs.Text = Req.inpzs;
            QiGuaFs.Text = Req.QiGuaFs;
            Qgdate.Text = Req.QiGuaSj.ToString("yyyy年MM月dd日HH时");
            ChineseString.Text = obj.ChineseString;
            string gj = "壬寅年 癸卯月 乙丑日 戊寅时";

            gj = obj.GanZhi;
            gj = gj.Insert(5, "<font color=\"red\">");
            gj = gj.Insert(24, "</font>");

            gj = gj.Insert(34, "<font color=\"red\">");
            gj = gj.Insert(53, "</font>");

            GanZhi.Text = gj;// obj.GanZhi;
            xk.Text = obj.Xk;
            Shengsha.Text = "驿马─" + obj.驿马 + " 贵人─" + obj.驿马 + "  桃花─" + obj.桃花 + "  禄─" + obj.禄 + "  天喜─" + obj.天喜 + "  天医─" + obj.天医 + "   灾煞─" + obj.灾煞 + "    谋星─" + obj.谋星 + "  劫煞─" + obj.劫煞 + "   将星─" + obj.将星 + "   贵文昌人─" + obj.贵文昌人 + "    羊刃─" + obj.羊刃 + "  ";
            zguName.Text = obj.Gua64s[0]?.Outer + obj.Gua64s[0]?.Interior + obj.Gua64s[0]?.GuaName + "（" + obj.Gua64s[0]?.GuaGong + obj.Gua64s[0].Gyhc + "）";
            gushen.Text = obj.Gua64s[0].GuSehn;

            if (obj.Gua64s[0].Yao1 == 1)
            { zyao1.Text = "▅▅▅▅▅"; }
            else
            { zyao1.Text = "▅▅  ▅▅"; }

            if (obj.Gua64s[0].Yao2 == 1)
            { zyao2.Text = "▅▅▅▅▅"; }
            else
            { zyao2.Text = "▅▅  ▅▅"; }

            if (obj.Gua64s[0].Yao3 == 1)
            { zyao3.Text = "▅▅▅▅▅"; }
            else
            { zyao3.Text = "▅▅  ▅▅"; }

            if (obj.Gua64s[0].Yao4 == 1)
            { zyao4.Text = "▅▅▅▅▅"; }
            else
            { zyao4.Text = "▅▅  ▅▅"; }

            if (obj.Gua64s[0].Yao5 == 1)
            { zyao5.Text = "▅▅▅▅▅"; }
            else
            { zyao5.Text = "▅▅  ▅▅"; }

            if (obj.Gua64s[0].Yao6 == 1)
            { zyao6.Text = "▅▅▅▅▅"; }
            else
            { zyao6.Text = "▅▅  ▅▅"; }


            ShengShou1.Text = obj.Gua64s[0].ShengShou1;
            ShengShou2.Text = obj.Gua64s[0].ShengShou2;
            ShengShou3.Text = obj.Gua64s[0].ShengShou3;
            ShengShou4.Text = obj.Gua64s[0].ShengShou4;
            ShengShou5.Text = obj.Gua64s[0].ShengShou5;
            ShengShou6.Text = obj.Gua64s[0].ShengShou6;

            Najia1.Text = obj.Gua64s[0].Qin1 + obj.Gua64s[0].Najia1;
            Najia2.Text = obj.Gua64s[0].Qin2 + obj.Gua64s[0].Najia2;
            Najia3.Text = obj.Gua64s[0].Qin3 + obj.Gua64s[0].Najia3;
            Najia4.Text = obj.Gua64s[0].Qin4 + obj.Gua64s[0].Najia4;
            Najia5.Text = obj.Gua64s[0].Qin5 + obj.Gua64s[0].Najia5;
            Najia6.Text = obj.Gua64s[0].Qin6 + obj.Gua64s[0].Najia6;


            Label labeShiYao = FindByName("Zgusy" + obj.Gua64s[0].ShiYao) as Label;
            labeShiYao.Text = "世";

            Label labeYingYao = FindByName("Zgusy" + obj.Gua64s[0].YingYao) as Label;
            labeYingYao.Text = "应";


            ///伏神
            //  fusheng1

            int fcout = obj.FuYaoId.Count;
            int fs1 = -1;
            int fs2 = -1;
            string s1 = "";
            string n1 = "";
            string s2 = "";
            string n2 = "";
            if (fcout > 0)
            {
                fs1 = obj.FuYaoId[0];
                s1 = obj.FuYao[0];
                n1 = obj.FuYaoNj[0];

                Label labebfuYao = FindByName("fusheng" + fs1) as Label;
                labebfuYao.Text = s1 + n1;
            }

            if (fcout > 1)
            {
                fs2 = obj.FuYaoId[1];
                s2 = obj.FuYao[1];
                n2 = obj.FuYaoNj[1];
                Label labebfuYao2 = FindByName("fusheng" + fs2) as Label;
                labebfuYao2.Text = s2 + n2;
            }

            ///显示动爻
            if (obj.Gua64s.Count > 1)
            {
                //1
                if (obj.Gua64s[0].IsDy1)
                {
                    if (obj.Gua64s[1].Yao1 == 1)
                    { dyao1.Text = "X"; }
                    else
                    { dyao1.Text = "O"; }

                }
                //2
                if (obj.Gua64s[0].IsDy2)
                {
                    if (obj.Gua64s[1].Yao2 == 1)
                    { dyao2.Text = "X"; }
                    else
                    { dyao2.Text = "O"; }

                }
                //3
                if (obj.Gua64s[0].IsDy3)
                {
                    if (obj.Gua64s[1].Yao3 == 1)
                    { dyao3.Text = "X"; }
                    else
                    { dyao3.Text = "O"; }

                }
                //4
                if (obj.Gua64s[0].IsDy4)
                {
                    if (obj.Gua64s[1].Yao4 == 1)
                    { dyao4.Text = "X"; }
                    else
                    { dyao4.Text = "O"; }

                }
                //5
                if (obj.Gua64s[0].IsDy5)
                {
                    if (obj.Gua64s[1].Yao5 == 1)
                    { dyao5.Text = "X"; }
                    else
                    { dyao5.Text = "O"; }

                }
                //6
                if (obj.Gua64s[0].IsDy6)
                {
                    if (obj.Gua64s[1].Yao1 == 1)
                    { dyao6.Text = "X"; }
                    else
                    { dyao6.Text = "O"; }

                }





                if (obj.Gua64s[1].Yao1 == 1)
                { byao1.Text = "▅▅▅▅▅"; }
                else
                { byao1.Text = "▅▅  ▅▅"; }

                if (obj.Gua64s[1].Yao2 == 1)
                { byao2.Text = "▅▅▅▅▅"; }
                else
                { byao2.Text = "▅▅  ▅▅"; }

                if (obj.Gua64s[1].Yao3 == 1)
                { byao3.Text = "▅▅▅▅▅"; }
                else
                { byao3.Text = "▅▅  ▅▅"; }

                if (obj.Gua64s[1].Yao4 == 1)
                { byao4.Text = "▅▅▅▅▅"; }
                else
                { byao4.Text = "▅▅  ▅▅"; }

                if (obj.Gua64s[1].Yao5 == 1)
                { byao5.Text = "▅▅▅▅▅"; }
                else
                { byao5.Text = "▅▅  ▅▅"; }

                if (obj.Gua64s[1].Yao6 == 1)
                { byao6.Text = "▅▅▅▅▅"; }
                else
                { byao6.Text = "▅▅  ▅▅"; }

                bNajia1.Text = obj.Gua64s[1].Qin1 + obj.Gua64s[1].Najia1;
                bNajia2.Text = obj.Gua64s[1].Qin2 + obj.Gua64s[1].Najia2;
                bNajia3.Text = obj.Gua64s[1].Qin3 + obj.Gua64s[1].Najia3;
                bNajia4.Text = obj.Gua64s[1].Qin4 + obj.Gua64s[1].Najia4;
                bNajia5.Text = obj.Gua64s[1].Qin5 + obj.Gua64s[1].Najia5;
                bNajia6.Text = obj.Gua64s[1].Qin6 + obj.Gua64s[1].Najia6;

                BzguName.Text = obj.Gua64s[1]?.Outer + obj.Gua64s[1]?.Interior + obj.Gua64s[1]?.GuaName + "（" + obj.Gua64s[1]?.GuaGong + obj.Gua64s[1].Gyhc + "）";

                //obj.Gua64s[1].ShiYao obj.Gua64s[1].YingYao
                Label labebShiYao = FindByName("Bgusy3") as Label;
                labebShiYao.Text = "世";

                Label labebYingYao = (Label)FindByName("Bgusy6");
                labebYingYao.Text = "应";



            }
            if (obj.Gua64s.Count == 1)
            {
                gridgua.ColumnDefinitions[4].Width = 0;
                gridgua.ColumnDefinitions[5].Width = 0;
                gridgua.ColumnDefinitions[6].Width = 0;

            }

            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = obj.Gua64s[0].Remark;
            // RemarkTxt.Text= obj.Gua64s[0].Remark;
           tdyaoci = obj.Gua64s[0].Remark;// htmlSource;
            l4.Text = obj.remark.title1;

           
            // HtmlMsg.Source = new HtmlWebViewSource { Html = tdyaoci };
            HtmlMsg.Text = System.Web.HttpUtility.HtmlDecode(tdyaoci);
            LabMsg.Text= yaoci = obj.remark.Remark1;

          
        }
        public ShowPage()
	{
            InitializeComponent();
            // 获取 Windows 窗口对象
          //var window = Application.Current.MainPage.Window. as MauiWinUIApplicationWindow;

            // 最大化窗口
         //   window.WindowPresenter.RequestPresentationMode(PresentationMode.Maximized);
        }
        protected override void OnHandlerChanged()
        {
            base.OnHandlerChanged();
#if WINDOWS
            Microsoft.UI.Xaml.Window window = (Microsoft.UI.Xaml.Window)App.Current.Windows.First<Window>().Handler.PlatformView;
            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
            Microsoft.UI.WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
            Microsoft.UI.Windowing.AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            appWindow.Resize(new Windows.Graphics.SizeInt32(950,1000));
#endif
        }
        public async Task<ImageSource> TakeScreenshotAsync()
        {
            if (Screenshot.Default.IsCaptureSupported)
            {
                IScreenshotResult screen = await Screenshot.Default.CaptureAsync();

                Stream stream = await screen.OpenReadAsync();

                return ImageSource.FromStream(() => stream);
            }

            return null;
        }

    }
}