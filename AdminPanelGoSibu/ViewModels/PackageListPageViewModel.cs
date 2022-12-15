using AdminPanelGoSibu.Services;
using AdminPanelGoSibu.Views;
using Gosibu.Shared.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AdminPanelGoSibu.ViewModels
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

        public ObservableCollection<PackageModel> Packages { get; set; } = new ObservableCollection<PackageModel>();
        #endregion

        #region Constructor
        [Obsolete]
        public PackageListPageViewModel()
        {
            _packageService = DependencyService.Resolve<PackageService>();
            GetAllPackageList();
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
                var response = await App.Current.MainPage.DisplayActionSheet("Options!", "Cancel", null, "Update Package", "Delete Package");

                if (response == "Update Package")
                {
                    await App.Current.MainPage.Navigation.PushAsync(new AddUpdatePackagePage(package));
                }
                else if (response == "Delete Package")
                {
                    IsBusy = true;
                    bool deleteResponse = await _packageService.DeletePackage(package);
                    if (deleteResponse)
                    {
                        Packages.Remove(package);
                    }
                    else
                    {
                        IsBusy = false;
                    }
                }
            }
        });
        #endregion

    }
}
