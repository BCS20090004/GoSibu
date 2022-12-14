﻿using AdminPanelGoSibu;
using AdminPanelGoSibu.Services;
using CommunityToolkit.Maui;

namespace MauiMapsSample;
public static class MauiProgram
{
    public static Microsoft.Maui.Hosting.MauiApp CreateMauiApp()
    {
        var builder = Microsoft.Maui.Hosting.MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiMaps().UseMauiCommunityToolkit();
        DependencyService.RegisterSingleton<IVoucherService>(new IVoucherService());
        return builder.Build();


    }
}