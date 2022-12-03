using AdminPanelGoSibu.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelGoSibu.Services.Interfaces
{
    public interface IVoucherService
    {
        Task<bool> AddOrUpdateVoucher(VoucherModel voucherModel);
        Task<bool> DeleteVoucher(string OfferName);
        Task<List<VoucherModel>> GetAllVoucher();
    }
}
