﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using AdminPanelGoSibu.Services;
using Shared.GoSibu.Models;


namespace AdminPanelGoSibu.ViewModels
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

        [Obsolete]
        public ICommand SelectedVoucherCommand => new Command<VoucherModel>(async (voucher) =>
        {
            if (voucher != null)
            {
                var response = await App.Current.MainPage.DisplayActionSheet("Options!", "Cancel", null, "Update Voucher", "Delete Voucher");

                if (response == "Update Voucher")
                {
                    await App.Current.MainPage.Navigation.PushAsync(new AddUpdateVoucherPage(voucher));
                }
                else if (response == "Delete Voucher")
                {
                    IsBusy = true;

                    try
                    {
                        bool deleteResponse = await _voucherService.DeleteVoucher(voucher);
                        if (deleteResponse)
                        {
                            //GetAllVoucherList();
                            Vouchers.Remove(voucher);
                        }
                        else
                        {
                            Console.WriteLine("Faile to remove voucher, try again.");
                        }
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("Error Occur with Http");

                    }
                    finally
                    {
                        IsBusy = false;

                    }
                }
            }
        });
        #endregion

    }
}
