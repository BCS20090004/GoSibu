using Gosibu.Shared.Models;


namespace GoSibu.Services
{
    public class IVoucherService : BaseApiService
    {
        
        public Task<List<VoucherModel>> GetAllVoucher()
        {

            return GetTAsync<List<VoucherModel>>("VoucherService");
        }


        //Task<bool> AddOrUpdateVoucher(VoucherModel voucherModel);
        //Task<bool> DeleteVoucher(string OfferName);
        //Task<List<VoucherModel>> GetAllVoucher();
    }

   
}
