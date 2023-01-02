using AdminPanelGoSibu.Services;
using System.Windows.Input;
using Shared.GoSibu.Models;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls.Maps;

namespace AdminPanelGoSibu.ViewModels
{
    public class AddUpdatePackagePageViewModel :BaseViewModel 
    {
        //list of new model containing lat,long,name
        #region Properties
        private readonly PackageService _packageService;

        private PackageModel _packageDetail = new PackageModel();

        public ObservableCollection<Pin> Pins { get; set; } = new();
        public PackageModel PackageDetail
        {   
            get => _packageDetail;
            set => SetProperty(ref _packageDetail, value);
        }

        #endregion

        #region Constructor
        public AddUpdatePackagePageViewModel()
        {
            _packageService = DependencyService.Resolve<PackageService>();
        }

        public AddUpdatePackagePageViewModel(PackageModel packageResponse)
        {
            _packageService = DependencyService.Resolve<PackageService>();
            PackageDetail = new PackageModel
            {
                Key = packageResponse.Key,
                PackageName = packageResponse.PackageName,
                Departure = packageResponse.Departure,
                Destination1 = packageResponse.Destination1,
                Destination2 = packageResponse.Destination2,
                Destination3 = packageResponse.Destination3,
                Destination4 = packageResponse.Destination4,
                Duration = packageResponse.Duration,
                PackagePrice = packageResponse.PackagePrice,
                PersonLimit = packageResponse.PersonLimit,
                DateandTIme = packageResponse.DateandTIme,
                Discription = packageResponse.Discription,
                Attention = packageResponse.Attention,
            };
        }

        #endregion

        #region Commands
        public ICommand SavePackageCommand => new Command(async () =>
        {
            if (IsBusy) return;
            IsBusy = true;
            var res = await _packageService.AddOrUpdatePackage(PackageDetail);
            if (res.IsSuccessStatusCode)
            {

                if (!string.IsNullOrWhiteSpace(PackageDetail.Key))
                {
                    await App.Current.MainPage.DisplayAlert("Success!", "Record Updated successfully.", "Ok");
                }
                else
                {
                    PackageDetail = new PackageModel() { };
                    await App.Current.MainPage.DisplayAlert("Success!", "Record added successfully.", "Ok");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Fail!", "Record Added failed.", "OK");
                IsBusy = false;
            }
        });
        #endregion
    }
}
