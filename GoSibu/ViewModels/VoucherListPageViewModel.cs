using System.Collections.ObjectModel;
using System.Windows.Input;
using GoSibu.Services;
using Gosibu.Shared.Models;

namespace GoSibu.ViewModels
{
    public class VoucherListPageViewModel : BaseViewModel
    {
        #region Properties
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        private readonly IVoucherService _voucherService;

        public ObservableCollection<VoucherModel> Vouchers { get; set; } = new ObservableCollection<VoucherModel>();
        #endregion

        #region Constructor
        [Obsolete]
        public VoucherListPageViewModel()
        {
            _voucherService = DependencyService.Resolve<IVoucherService>();
            GetAllVoucherList();
        }
        #endregion

        #region Methods
        [Obsolete]
        private void GetAllVoucherList()
        {
            IsBusy = true;
            Task.Run(async () =>
            {
                var voucherLIst = await _voucherService.GetAllVoucher();

                Device.BeginInvokeOnMainThread(() =>
                {

                    Vouchers.Clear();
                    if (voucherLIst?.Count > 0)
                    {
                        foreach (var voucher in voucherLIst)
                        {
                            Vouchers.Add(voucher);
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
            GetAllVoucherList();
        });
        #endregion


    }
}
