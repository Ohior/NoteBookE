using Microsoft.Extensions.Logging;
using NoteBook.Model;
using NoteBook.ViewModel;
using NoteBook.Views;

namespace NoteBook
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<NoteBookDatabase>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<DetailPageViewModel>();

            builder.Services.AddTransient<EditPage>();
            builder.Services.AddTransient<EditPageViewModel>();

            return builder.Build();
        }
    }
}