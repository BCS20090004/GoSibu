using AdminPanelGoSibu.Models;
using AdminPanelGoSibu.Services.Implementations;
using AdminPanelGoSibu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
            bool res = await _voucherService.AddOrUpdateVoucher(VoucherDetail);
            if (res)
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
            IsBusy = false;
        });
        #endregion
    }
}

