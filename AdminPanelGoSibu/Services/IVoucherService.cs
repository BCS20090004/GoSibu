using Gosibu.Shared.Models;


namespace AdminPanelGoSibu.Services
{
    public class IVoucherService : BaseApiService
    {
        
        public Task<List<VoucherModel>> GetAllVoucher()
        {
            return GetTAsync<List<VoucherModel>>("VoucherModel");
        }

        public Task<HttpResponseMessage> AddOrUpdateVoucher(VoucherModel voucherModel)
        {
            return PostTAsync("VoucherModel", voucherModel);
            return PutAsync("VoucherModel", voucherModel);
            DeleteAsync("VoucherModel"); //DeleteVoucher???
        }

        //Task<bool> AddOrUpdateVoucher(VoucherModel voucherModel);
        //Task<bool> DeleteVoucher(string OfferName);
        //Task<List<VoucherModel>> GetAllVoucher();
    }

}
