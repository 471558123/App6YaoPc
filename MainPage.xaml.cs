
using App6Yao.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace App6Yao
{

public partial class MainPage : ContentPage
{
	int count = 0;
    private string _selectedOption;
    public MainPage()
	{
		InitializeComponent();

            App.iSLoginSuccessful += App_iSLoginSuccessful;


            Items = new ObservableCollection<ItemModel>
        {
            new ItemModel { Id = 1, Name = "电脑模拟" },
            new ItemModel { Id = 2, Name = "手动指定" },
            // 添加更多的数据
        };
            ///卦爻选择
            foreach (string colorName in GetKeyValuePairs.Keys)
            {
                pickerYao6.Items.Add(colorName);
                pickerYao5.Items.Add(colorName);
                pickerYao4.Items.Add(colorName);
                pickerYao3.Items.Add(colorName);
                pickerYao2.Items.Add(colorName);
                pickerYao1.Items.Add(colorName);
               

            }
            pickerYao6.SelectedIndex =0;
            pickerYao5.SelectedIndex = 0;
            pickerYao4.SelectedIndex = 0;
            pickerYao3.SelectedIndex = 0;
            pickerYao2.SelectedIndex = 0;
            pickerYao1.SelectedIndex = 0;

            qiGuaFs.ItemsSource = Items;
            qiGuaFs.SelectedIndex = 0; // 默认选中 John
           UserLongGettocken();

            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            MyStackLayout.GestureRecognizers.Add(panGesture);


            //btnMin.Click += (s, e) => { this.WindowState = WindowState.Minimized; };
            //btnMax.Click += (s, e) =>
            //{
            //    if (this.WindowState == WindowState.Maximized)
            //        this.WindowState = WindowState.Normal;
            //    else
            //        this.WindowState = WindowState.Maximized;
            //};
            //btnClose.Click += async (s, e) =>
            //{
            //    var dialogResult = await dialogHostService.Question("温馨提示", "确认退出系统?");
            //    if (dialogResult.Result != Prism.Services.Dialogs.ButtonResult.OK) return;
            //    this.Close();
            //};
            //ColorZone.MouseMove += (s, e) =>
            //{
            //    if (e.LeftButton == MouseButtonState.Pressed)
            //        this.DragMove();
            //};

            //ColorZone.MouseDoubleClick += (s, e) =>
            //{
            //    if (this.WindowState == WindowState.Normal)
            //        this.WindowState = WindowState.Maximized;
            //    else
            //        this.WindowState = WindowState.Normal;
            //};

        }
        double x, y;
        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    x = Content.TranslationX;
                    y = Content.TranslationY;
                    break;
                case GestureStatus.Running:
                    Content.TranslationX = x + e.TotalX;
                    Content.TranslationY = y + e.TotalY;
                    break;
            }
        }
        public async Task<bool> UserLongGettocken()
        {
            // notificationManager.SendNotification("这是个测试", "能正常显示内容了", DateTime.Now.AddSeconds(10));
            bool t = false;
            try
            {
                if (await App.AutoLogin())
                {
                    t = true;
                }
                else
                {
                    t = false;
                }
            }
            catch (Exception ex)
            { throw new Exception("登录错误", ex); }

            return t;
        }
        public ObservableCollection<ItemModel> Items { get; set; }
        public static string tockenStr = "";
   // public static Models.UserModel user;
    public static string url = "https://yao.yyzfs.ren"; // https://192.168.31.9:5000
    string yaokey1, yaokey2, yaokey3, yaokey4, yaokey5, yaokey6;
    private void qiGuaFs_SelectedIndexChanged(object sender, EventArgs e)
    {
            if (qiGuaFs == null)
            { return; }
        string colorName = qiGuaFs.Items[qiGuaFs.SelectedIndex];
        if (qiGuaFs.SelectedIndex == 0)
        {
            dnmnyg.IsVisible = true;
            sdzd.IsVisible = false;
           // contentHeight.HeightRequest = 360;
        }
        if (qiGuaFs.SelectedIndex == 1)
        {
            sdzd.IsVisible = true;
            dnmnyg.IsVisible = false;
           // contentHeight.HeightRequest = 540;
        }
        //  string action = await DisplayActionSheet("请选择", "取消", null, "▅▅▅▅▅一个背　少阳", "▅▅　▅▅二个背　少阴", "▅▅▅▅▅O三个背　老阳", "▅▅　▅▅X三个面　老阴");
    }
    private async void Button2_Clicked(object sender, EventArgs e)
    {



        //手动指定卦
        if (qiGuaFs.SelectedIndex > 0)
        {
            if (string.IsNullOrEmpty(yaokey1) || string.IsNullOrEmpty(yaokey2) || string.IsNullOrEmpty(yaokey3) || string.IsNullOrEmpty(yaokey4) || string.IsNullOrEmpty(yaokey5) || string.IsNullOrEmpty(yaokey6))
            {
                await DisplayAlert("没完成手动指定卦爻", "请完成指定卦爻", "确定");
                return;
            }
            list.Clear();
            list.Add(yaokey1);
            list.Add(yaokey2);
            list.Add(yaokey3);
            list.Add(yaokey4);
            list.Add(yaokey5);
            list.Add(yaokey6);
        }
        if (list.Count >= 6)
        { postUrl(); }
        else
        { await DisplayAlert("提示", "请完成摇卦", "确定"); }


    }
    System.Timers.Timer timer = new System.Timers.Timer();
    Dictionary<string, string> nameToColor = new Dictionary<string, string>
        {
            { "电脑模拟", "电脑模拟" }, { "手动指定", "手动指定" },

        };

    Dictionary<string, string> GetKeyValuePairs = new Dictionary<string, string>
        {
            { "▅▅▅▅▅一个花　少阳", "100" },
            { "▅▅　▅▅一个字　少阴", "011" },
            { "▅▅▅▅▅O三个花　老阳", "111" },
            { "▅▅　▅▅X三个字　老阴", "000" }
        };
    System.Timers.Timer timersTimer = new System.Timers.Timer(1000 * 60 * 3); //3分钟
    private async void timersTimer_Elapsed(object sender, EventArgs e)
    {


        try
        {
          //  await UserLongGettocken();
        }
        catch (Exception ex)
        {
            // await DisplayAlert("提示", "登录服务器超时，请关闭重新打开再试", "确定");
        }


        //Application.Current.Properties.Remove("UserName");
        //Application.Current.Properties.Remove("Password");
        //await Application.Current.SavePropertiesAsync();
        //await App.AutoLogin();
        //App.OnNumChanged();

    }
    private void starttimer()
    {

        if (list.Count >= 6)
        {
            be.Text = "摇卦完成请排盘";
            zz.Text = "";
            zzz.Text = "";
            return;
        }

        timer.Interval = 100;
        timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
        timer.Enabled = true;
        timer.Start();

    }
    List<string> list = new List<string>();
    private void endtimer()
    {
        if (list.Count >= 6)
        {
            be.Text = "摇卦完成请排盘";
            zz.Text = "";
            zzz.Text = "";
            return;
        }
        timer.Enabled = false;
        timer.Stop();
        if (!string.IsNullOrEmpty(v) && list.Count < 6)
        {

            list.Add(v);
            ygcs = ygcs + 1;
            zz.Text = (ygcs).ToString();



        }

    }
    string v = "";
    private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        int r1 = new Random().Next(0, 2);
        int r2 = new Random().Next(0, 2);
        int r3 = new Random().Next(0, 2);
        v = r1 + "" + r2 + "" + r3;
            MainThread.BeginInvokeOnMainThread(() =>
        {
            img1.Source = "yao" + r1 + ".png";
            img2.Source = "yao" + r2 + ".png";
            img3.Source = "yao" + r3 + ".png";
       });

    }

    bool t = true;
    int ygcs = 1;
    private void Button3_Clicked(object sender, EventArgs e)
    {
        if (list.Count >= 6)
        {
            be.Text = "摇卦完成请排盘";
            zz.Text = "";
            zzz.Text = "";
            endtimer();
            return;
        }
        if (t)
        {

            starttimer();
            t = false;
            be.Text = "结束第：";

        }
        else
        {
            endtimer();
            t = true;
            if (list.Count >= 6)
            {
                be.Text = "摇卦完成请排盘";
                zz.Text = "";
                zzz.Text = "";


            }
            else { be.Text = "开始第："; }

        }

    }

    private async void postUrl()
    {
        if (string.IsNullOrEmpty(BaseEntity.tockenStr))
        {
            await DisplayAlert("没有授权信息", "请重启APP", "确定");
            return;
        }



        string QiGuaFsStr = "电脑模拟";
        if (qiGuaFs.SelectedIndex > -1)
            { 
                QiGuaFsStr = qiGuaFs.Items[qiGuaFs.SelectedIndex];
            }




        //HttpWebRequest wReq2 = (HttpWebRequest)WebRequest.Create(url + "/api/Gua/YaoGua");
        //wReq2.Method = "Post";
        //wReq2.Headers.Add("Authorization", "Bearer " + tockenStr);
        //wReq2.ContentType = "application/json";

        ReqEntity reqEntity = new ReqEntity();

        DateTime dt = new DateTime(qiGuaSj.Date.Year, qiGuaSj.Date.Month, qiGuaSj.Date.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, 1);
        reqEntity.QiGuaSj = dt;
        //reqEntity.rdoSex = sexStr;
        reqEntity.QiGuaFs = QiGuaFsStr;
        //reqEntity.whyarea = whyarea.SelectedIndex;
        //reqEntity.whyareaName = whyareaNameStr;
        reqEntity.inpzs = inpzs.Text;
        //reqEntity.txtNL = int.Parse(txtNL.Text);
        //reqEntity.shuxiang = shuxiangstr;
        //reqEntity.txtName = txtName.Text;
        reqEntity.Gyao = list;
        reqEntity.tockenStr = "";
        string postStr = JsonConvert.SerializeObject(reqEntity);
        //   string postStr = "{\"txtName\": \"1\",\"inpzs\": \"1\",\"whyarea\": 0,\"whyareaName\": \"1\",\"qiGuaFs\": \"1\",\"rdoSex\": \"1\",\"txtNL\": 0,\"gyao\": [  \"010\",\"110\",\"110\",\"100\",\"100\",\"100\"],\"remark\": \"string\"}";
        //byte[] data2 = Encoding.Default.GetBytes(postStr);
        //wReq2.ContentLength = data2.Length;
        //Stream reqStream2 = wReq2.GetRequestStream();
        //reqStream2.Write(data2, 0, data2.Length);
        //reqStream2.Close();
        //using (StreamReader sr2 = new StreamReader(wReq2.GetResponse().GetResponseStream()))
        //{
        //    string result2 = sr2.ReadToEnd();
        //    GuaView obj = JsonConvert.DeserializeObject<GuaView>(result2);
        //    //  await Navigation.PushAsync(new ShowPage(obj));
        //    await App.GlobalNavigation.PushAsync(new ShowPage(obj, reqEntity));
        //    // Page1 secondPage =  new Page1();
        //    // await Device.InvokeOnMainThreadAsync(() => Navigation.PushAsync(secondPage, true));
        //}

        //if (wReq2 != null)
        //{
        //    wReq2.Abort();
        //}





        //var httpClient = HttpClientHelper.HttpClient;

        //// 创建身份认证
        //// System.Net.Http.Headers.AuthenticationHeaderValue;
        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BaseEntity.tockenStr);
        //HttpContent content = new StringContent(postStr);
        //content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        //string url = BaseEntity.url + "/api/Gua/YaoGua";
        //HttpResponseMessage response = await httpClient.PostAsync(url, content);//改成自己的
        //response.EnsureSuccessStatusCode();//用来抛异常的
        //string result = await response.Content.ReadAsStringAsync();
        //GuaView obj = JsonConvert.DeserializeObject<GuaView>(result);

        string result = "";



        //  await App.GlobalNavigation.PushAsync(new ShowPage(obj, reqEntity));
        await Shell.Current.GoToAsync($"{nameof(ShowPage)}?gujson={System.Web.HttpUtility.UrlEncode(postStr)}&reqjson={result}");
        // Shell.Current.CurrentItem.CurrentItem.Items.Add(new ShowPage(obj, reqEntity));

    }
    private void pickerYao1_SelectedIndexChanged(object sender, EventArgs e)
    {
        yaokey1 = GetKeyValuePairs[pickerYao1.Items[pickerYao1.SelectedIndex]];
    }



    private void pickerYao6_SelectedIndexChanged(object sender, EventArgs e)
    {
        yaokey6 = GetKeyValuePairs[pickerYao6.Items[pickerYao6.SelectedIndex]];
    }

    private void Button1_Clicked(object sender, EventArgs e)
    {

    }
        //属相选中值
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 通过 SelectedItem 获取选中的值并显示
           // selectedValueLabel.Text = myPicker.SelectedItem?.ToString();
        }

        private void pickerYao5_SelectedIndexChanged(object sender, EventArgs e)
    {
        yaokey5 = GetKeyValuePairs[pickerYao5.Items[pickerYao5.SelectedIndex]];
    }

    private void pickerYao4_SelectedIndexChanged(object sender, EventArgs e)
    {
        yaokey4 = GetKeyValuePairs[pickerYao4.Items[pickerYao4.SelectedIndex]];
    }

    private void pickerYao3_SelectedIndexChanged(object sender, EventArgs e)
    {
        yaokey3 = GetKeyValuePairs[pickerYao3.Items[pickerYao3.SelectedIndex]];
    }

    private void pickerYao2_SelectedIndexChanged(object sender, EventArgs e)
    {
        yaokey2 = GetKeyValuePairs[pickerYao2.Items[pickerYao2.SelectedIndex]];
    }





    private void App_iSLoginSuccessful()
    {
        //var task = Task.Run(() => {
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        // LoginSuccessful.IsVisible = true; ;

        Butppan.IsVisible = true;
        //  Thread.Sleep(3000);
        //  LoginSuccessful.IsVisible = false;

        //    });
        //});




        //  await PopupNavigation.Instance.PushAsync(new PayPage(1));
    }

        protected override void OnHandlerChanged()
        {
            base.OnHandlerChanged();
#if WINDOWS
            Microsoft.UI.Xaml.Window window = (Microsoft.UI.Xaml.Window)App.Current.Windows.First<Window>().Handler.PlatformView;
            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
            Microsoft.UI.WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
            Microsoft.UI.Windowing.AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            appWindow.Resize(new Windows.Graphics.SizeInt32(650,1000));
#endif
        }
    }
    public class ItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}

