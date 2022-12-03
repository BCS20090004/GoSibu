using System.Collections.ObjectModel;
using System.Windows.Input;
//using AdminPanelGoSibu;
//using AdminPanelGoSibu.Services.Interfaces;
//using AdminPanelGoSibu.Models;

namespace GoSibu.ViewModels;

public class VoucherPageViewModel : BaseViewModel
{
    //#region Properties
    //private bool _isRefreshing;
    //public bool IsRefreshing
    //{
    //    get => _isRefreshing;
    //    set => SetProperty(ref _isRefreshing, value);
    //}

    //private readonly IVoucherService _voucherService;

    //public ObservableCollection<VoucherModel> Vouchers { get; set; } = new ObservableCollection<VoucherModel>();
    //#endregion

    //#region Constructor
    public VoucherPageViewModel()
    {
        //_voucherService = DependencyService.Resolve<IVoucherService>();
        //GetAllVoucher();
    }
    //#endregion

    //#region Methods
    //[Obsolete]
    //private void GetAllVoucher()
    //{
    //    IsBusy = true;
    //    Task.Run(async () =>
    //    {
    //        var voucherLIst = await _voucherService.GetAllVoucher();

    //        Device.BeginInvokeOnMainThread(() =>
    //        {

    //            Vouchers.Clear();
    //            if (voucherLIst?.Count > 0)
    //            {
    //                foreach (var voucher in voucherLIst)
    //                {
    //                    Vouchers.Add(voucher);
    //                }
    //            }
    //            IsBusy = IsRefreshing = false;
    //        });

    //    });
    //}
    //#endregion

    //#region Commands

    //public ICommand RefreshCommand => new Command(() =>
    //{
    //    IsRefreshing = true;
    //    GetAllVoucher();
    //});

    //public ICommand SelectedVoucherCommand => new Command<VoucherModel>(async (voucher) =>
    //{
    //    if (voucher != null)
    //    {
    //        var response = await App.Current.MainPage.DisplayActionSheet("Options!", "Cancel", null, "Update Voucher", "Delete Voucher");

    //        if (response == "Update Voucher")
    //        {
    //            await App.Current.MainPage.Navigation.PushAsync(new AddUpdateVoucherPage(voucher));
    //        }
    //        else if (response == "Delete Voucher")
    //        {
    //            IsBusy = true;
    //            bool deleteResponse = await _voucherService.DeleteVoucher(voucher.Key);
    //            if (deleteResponse)
    //            {
    //                GetAllVoucher();
    //            }
    //        }
    //    }
    //});
    //#endregion

}
