using Gosibu.Shared.Models;


namespace GoSibu.Services
{
    public class IVoucherService : BaseApiService
    {
        
        public Task<List<VoucherModel>> GetAllVoucher()
        {

            return GetTAsync<List<VoucherModel>>("VoucherService");
        }
        public Task<HttpResponseMessage> AddOrUpdateVoucher(VoucherModel voucherModel)
        {
            return PutAsync("VoucherService", voucherModel);
        }

        //Task<bool> AddOrUpdateVoucher(VoucherModel voucherModel);
        //Task<bool> DeleteVoucher(string OfferName);
        //Task<List<VoucherModel>> GetAllVoucher();
    }
   
}
