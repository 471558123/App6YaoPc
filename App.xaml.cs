using App6Yao.Models;
using Newtonsoft.Json;

namespace App6Yao;

public partial class App : Application
{
    public delegate void NumManipulationHandler();
    public delegate void NumAskHandler();
    public delegate void LoginSuccessfulHandler();
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
     
    }
  
    public static async Task<bool> AutoLogin()
    {
        bool t = false;
        try
        {
           
          

                ///只有摇卦权限的通用，用户
                t = await HttpClientHelper.Gettocken("test", "123456789");

           
        }
        catch
        {
            if (string.IsNullOrEmpty(BaseEntity.tockenStr))
            {
                ///只有摇卦权限的通用，用户
                t = await HttpClientHelper.Gettocken("test", "123456789");
            }
            else
            { t = true; }
        }

        if (t)
        {
            LoginSuccessfulChanged();
        }

        return t;



    }
    public static event NumManipulationHandler ChangeNum;
    public static void OnNumChanged()
    {
        if (ChangeNum != null)
        {
            ChangeNum(); /* 事件被触发 */
        }

    }
    /// <summary>
    ///收到问卦信息
    /// </summary>
    public static event NumAskHandler ChangeAsk;
    public static void OnChangeAskChanged()
    {
        if (ChangeAsk != null)
        {
            ChangeAsk(); /* 事件被触发 */
        }

    }
    public static event LoginSuccessfulHandler iSLoginSuccessful;
    public static void LoginSuccessfulChanged()
    {
        if (iSLoginSuccessful != null)
        {
            iSLoginSuccessful(); /* 事件被触发 */
        }

    }
}
