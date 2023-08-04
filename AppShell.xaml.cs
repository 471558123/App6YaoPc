namespace App6Yao;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(ShowPage), typeof(ShowPage));
    }
}
