using GoSibu.Services;
using GoSibu.Views;
using Shared.GoSibu.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GoSibu.ViewModels
{
    public class PackageListPageViewModel :BaseViewModel
    {

        #region Properties

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        private readonly PackageService _packageService;
        private int _position;
        public int Position
        {
            get => _position;
            set => SetProperty(ref _position, value, onChanged: (() =>
            {
            }));
        }
        public ObservableCollection<PackageModel> MainPage { get; set; } = new ObservableCollection<PackageModel>();

        public ObservableCollection<PackageModel> Packages { get; set; } = new ObservableCollection<PackageModel>();
        #endregion

        #region Constructor
        [Obsolete]
        public PackageListPageViewModel()
        {
            _packageService = DependencyService.Resolve<PackageService>();
            GetAllPackageList();

            MainPage.Add(new PackageModel
            {
                IntroImage = "ad2"
            });

            MainPage.Add(new PackageModel
            {

                IntroImage = "ad1"
            });

            MainPage.Add(new PackageModel
            {

                IntroImage = "ad3"
            });
        }
        #endregion

        #region Methods
        [Obsolete]
        private void GetAllPackageList()
        {
            IsBusy = true;
            Task.Run(async () =>
            {
                var packageLIst = await _packageService.GetAllPackage();

                Device.BeginInvokeOnMainThread(() =>
                {

                    Packages.Clear();
                    if (packageLIst?.Count > 0)
                    {
                        foreach (var package in packageLIst)
                        {
                            Packages.Add(package);
                        }
                    }
                    IsBusy = IsRefreshing = false;
                });

            });
        }
        #endregion

        #region Commands

        [Obsolete]
        public ICommand RefreshCommand => new Command(() =>
        {
            IsRefreshing = true;
            GetAllPackageList();
        });

        public ICommand SelectedPackageCommand => new Command<PackageModel>(async (package) =>
        {
            if (package != null)
            {
                await App.Current.MainPage.Navigation.PushAsync(new PurchasePage(package));

            }
        });

        #endregion

    }
}
