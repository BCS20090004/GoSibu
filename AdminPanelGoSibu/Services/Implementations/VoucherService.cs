using AdminPanelGoSibu.Models;
using Firebase.Database;
using Firebase.Database.Query;
using Gosibu.Shared.Models;

namespace AdminPanelGoSibu.Services.Implementations
{
    public class VoucherService : IVoucherService
    {
        FirebaseClient firebase = new FirebaseClient(Setting.FireBaseDatabaseUrl, new FirebaseOptions
        {
            AuthTokenAsyncFactory = () => Task.FromResult(Setting.FireBaseSeceret)
        });

        public new async Task<bool> AddOrUpdateVoucher(VoucherModel voucherModel)
        {
            if (!string.IsNullOrWhiteSpace(voucherModel.Key))
            {
                try
                {
                    await firebase.Child(nameof(VoucherModel)).Child(voucherModel.Key).PutAsync(voucherModel);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                var response = await firebase.Child(nameof(VoucherModel)).PostAsync(voucherModel);
                if (response.Key != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
         
        }

        public async Task<bool> DeleteVoucher(string key)
        {
            try
            {
                await firebase.Child(nameof(VoucherModel)).Child(key).DeleteAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<VoucherModel>> GetAllVoucher()
        {
            return (await firebase.Child(nameof(VoucherModel)).OnceAsync<VoucherModel>()).Select(f => new VoucherModel
            {
                OfferName = f.Object.OfferName,
                Duration = f.Object.Duration,
                Offer = f.Object.Offer,
                Description = f.Object.Description,
                Key = f.Key
            }).ToList();

        }
    }
}
