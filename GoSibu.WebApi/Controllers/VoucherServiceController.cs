using Microsoft.AspNetCore.Mvc;
using Gosibu.Shared.Models;
using Firebase.Database;
using Firebase.Database.Query;
using GoSibu.WebApi.Models;

namespace GoSibu.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoucherServiceController : ControllerBase
    {
        FirebaseClient firebase = new FirebaseClient(Setting.FireBaseDatabaseUrl, new FirebaseOptions
        {
            AuthTokenAsyncFactory = () => Task.FromResult(Setting.FireBaseSeceret)
        });

        private readonly ILogger<VoucherServiceController> _logger;

        public VoucherServiceController(ILogger<VoucherServiceController> logger)
        {
            _logger = logger;
        }

        [HttpPut(Name = "AddorUpdateVoucher")]

        public async Task<bool> AddOrUpdateVoucher(VoucherModel voucherModel)
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

        [HttpDelete(Name = "DeleteVoucher")]
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

        [HttpGet(Name = "GetAllVoucher")]
        public async Task<List<VoucherModel>> GetAllVoucher()
        {
            return (await firebase.Child(nameof(VoucherModel)).OnceAsync<VoucherModel>()).Select(f => new VoucherModel
            {
                OfferName = f.Object.OfferName,
                Duration = f.Object.Duration,
                Offer = f.Object.Offer,
                OfferPercent = f.Object.OfferPercent,
                Description = f.Object.Description,
                Key = f.Key
            })
            .ToList();
        }
    }
}