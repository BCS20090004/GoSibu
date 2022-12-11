using AdminPanelGoSibu.Services;
using AdminPanelGoSibu.Services.Implementations;

namespace AdminPanelGoSibu
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            //DepndencyService.Register<IVoucherService, VoucherService>();

        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}