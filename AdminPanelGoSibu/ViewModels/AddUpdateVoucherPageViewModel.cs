using System.Windows.Input;
using VoucherModel = Gosibu.Shared.Models.VoucherModel;
using AdminPanelGoSibu.Services;
using Gosibu.Shared.Models;

namespace AdminPanelGoSibu.ViewModels
{
    public class AddUpdateVoucherPageViewModel : BaseViewModel
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
        public AddUpdateVoucherPageViewModel()
        {
            _voucherService = DependencyService.Resolve<IVoucherService>();
        }

        public AddUpdateVoucherPageViewModel(VoucherModel voucherResponse)
        {
            _voucherService = DependencyService.Resolve<IVoucherService>();
            VoucherDetail = new VoucherModel
            {
                OfferName = voucherResponse.OfferName,
                Offer = voucherResponse.Offer,
                OfferPercent = voucherResponse.OfferPercent,
                Key = voucherResponse.Key,
                Duration = voucherResponse.Duration,
                Description = voucherResponse.Description,
            };
        }
        #endregion

        #region Commands
        public ICommand SaveVoucherCommand => new Command(async () =>
        {
            if (IsBusy) return;
            IsBusy = true;
            var res = await _voucherService.AddOrUpdateVoucher(VoucherDetail); //from bool to HTTPRespnde Message
            if (res.IsSuccessStatusCode)
            {

                if (!string.IsNullOrWhiteSpace(VoucherDetail.Key))
                {
                    await App.Current.MainPage.DisplayAlert("Success!", "Record Updated successfully.", "Ok");
                }
                else
                {
                    VoucherDetail = new VoucherModel() { };
                    await App.Current.MainPage.DisplayAlert("Success!", "Record added successfully.", "Ok");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Failed!", "Please try again later.", "Ok");
            }
            IsBusy = false;
        });
        #endregion
    }
}
