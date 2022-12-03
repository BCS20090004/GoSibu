using AdminPanelGoSibu.Services.Implementations;
using AdminPanelGoSibu.Services.Interfaces;

namespace AdminPanelGoSibu
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            DependencyService.Register<IVoucherService, VoucherService>();

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