using developer_evaluation_btg.Data;
using developer_evaluation_btg.Services;
using developer_evaluation_btg.View;
using developer_evaluation_btg.ViewModel;
using Microsoft.Extensions.Logging;

namespace developer_evaluation_btg
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
            builder.Services.AddSingleton<IClientService, ClientService>();
            builder.Services.AddTransient<DbContext>();

            //main page          
            builder.Services.AddTransient<ClientListViewModel>();
            builder.Services.AddSingleton<ClientListPage>();

            builder.Services.AddTransient<ClientDetailViewModel>();            
            builder.Services.AddTransient<ClientDetailPage>();
           
            return builder.Build();
        }
    }
}
