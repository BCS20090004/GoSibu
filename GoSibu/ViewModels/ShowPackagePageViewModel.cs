using GoSibu.Services;
using Gosibu.Shared.Models;

namespace GoSibu.ViewModels
{
    public class ShowPackagePageViewModel : BaseViewModel
    {
        #region Properties
        private readonly PackageService _packageService;

        private PackageModel _packageDetail = new PackageModel();
        public PackageModel PackageDetail
        {
            get => _packageDetail;
            set => SetProperty(ref _packageDetail, value);
        }
        #endregion

        #region Constructor
        public ShowPackagePageViewModel()
        {
            _packageService = DependencyService.Resolve<PackageService>();
        }

        public ShowPackagePageViewModel(PackageModel packageResponse)
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
    }
}