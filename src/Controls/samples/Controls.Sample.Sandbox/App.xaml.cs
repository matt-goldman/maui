namespace Maui.Controls.Sample;

public partial class App : Application
{
	private readonly Page _page;

	public App()//MainPage page)
	{
		InitializeComponent();
		_page = new MainPage();// page;
    }

	protected override Window CreateWindow(IActivationState? activationState)
	{
		// To test shell scenarios, change this to true
		bool useShell = false;

		if (!useShell)
		{
			return new Window(new NavigationPage(_page));
		}
		else
		{
			return new Window(new SandboxShell());
		}
	}
}
