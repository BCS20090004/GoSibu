using SkiaSharp.Views.Maui.Controls.Hosting;
using CommunityToolkit.Maui;
using GoSibu.Services;

namespace GoSibu;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .UseMauiMaps()
            .ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();
        DependencyService.RegisterSingleton<IVoucherService>(new IVoucherService());
        DependencyService.RegisterSingleton<PackageService>(new PackageService());

        return builder.Build();
    }
}