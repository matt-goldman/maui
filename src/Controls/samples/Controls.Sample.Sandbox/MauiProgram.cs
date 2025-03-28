﻿namespace Maui.Controls.Sample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        var builder = MauiApp
            .CreateBuilder()
#if __ANDROID__ || __IOS__
            .UseMauiMaps()
#endif
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Dokdo-Regular.ttf", "Dokdo");
                fonts.AddFont("LobsterTwo-Regular.ttf", "Lobster Two");
                fonts.AddFont("LobsterTwo-Bold.ttf", "Lobster Two Bold");
                fonts.AddFont("LobsterTwo-Italic.ttf", "Lobster Two Italic");
                fonts.AddFont("LobsterTwo-BoldItalic.ttf", "Lobster Two BoldItalic");
                fonts.AddFont("ionicons.ttf", "Ionicons");
                fonts.AddFont("SegoeUI.ttf", "Segoe UI");
                fonts.AddFont("SegoeUI-Bold.ttf", "Segoe UI Bold");
                fonts.AddFont("SegoeUI-Italic.ttf", "Segoe UI Italic");
                fonts.AddFont("SegoeUI-Bold-Italic.ttf", "Segoe UI Bold Italic");
            })
            .ConfigureResources(resources =>
            {
                resources.AddXaml("Resources/Styles/Colors.xaml");
                resources.AddXaml("Resources/Styles/Styles.xaml");
                resources.Add("TestDirect", Color.FromRgba(16, 22, 56, 0.5));
            });

        builder.Services.AddTransient<MainPage>();

        return builder.Build();
    }
}
