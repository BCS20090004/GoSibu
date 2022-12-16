using GoSibu.Services;
using Gosibu.Shared.Models;

namespace GoSibu.ViewModels
{
    public class ShowVoucherPageViewModel :BaseViewModel
    {
        #region Properties
        private readonly IVoucherService _voucherService;

        private VoucherModel _voucherDetail = new VoucherModel();
        public VoucherModel VoucherDetail
        {
            get => _voucherDetail;
            set => SetProperty(ref _voucherDetail, value);
        }
        #endregion

        #region Constructor
        public ShowVoucherPageViewModel()
        {
            _voucherService = DependencyService.Resolve<IVoucherService>();
        }

        public ShowVoucherPageViewModel(VoucherModel voucherResponse)
        {
            _voucherService = DependencyService.Resolve<IVoucherService>();
            VoucherDetail = new VoucherModel
            {
                Key = voucherResponse.Key,
                OfferName = voucherResponse.OfferName,
                OfferPercent = voucherResponse.OfferPercent,
                Duration = voucherResponse.Duration,
                Offer = voucherResponse.Offer,
                Description = voucherResponse.Description,
            };
        }
        #endregion
    }
}
