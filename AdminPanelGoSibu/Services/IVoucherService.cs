using Shared.GoSibu.Models;


namespace AdminPanelGoSibu.Services
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

        public Task<bool> DeleteVoucher(VoucherModel voucherModel)
        {
            return DeleteAsync($"VoucherService?key={voucherModel.Key}");
        }

        //Task<bool> AddOrUpdateVoucher(VoucherModel voucherModel);
        //Task<bool> DeleteVoucher(string OfferName);
        //Task<List<VoucherModel>> GetAllVoucher();
    }

    //public interface ITestService
    //{
    //    Task<List<VoucherModel>> GetAllVoucher();
    //}

    //public class MockTestService : ITestService
    //{
    //    public Task<List<VoucherModel>> GetAllVoucher()
    //    {
    //        return Task.FromResult(new List<VoucherModel>()
    //        {
    //            new VoucherModel
    //            {
    //                Description= "description",
    //            },
    //             new VoucherModel
    //            {
    //                Description= "description",
    //            },
    //        });
    //    }
    //}
    //public class TestService : BaseApiService, ITestService
    //{
    //    public Task<List<VoucherModel>> GetAllVoucher()
    //    {
    //        return GetTAsync<List<VoucherModel>>("VoucherModel");
    //    }
    //}
    //List<int> test = new();
    //lambda expression
    //linq
    //test.Where(x => x == 1);
}
