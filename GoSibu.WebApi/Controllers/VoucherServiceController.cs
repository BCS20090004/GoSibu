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

        [HttpGet(Name = "GetAllVoucher")]
        public async Task<List<VoucherModel>> GetAllVoucher()
        {
            return (await firebase.Child(nameof(VoucherModel)).OnceAsync<VoucherModel>()).Select(f => new VoucherModel
            {
                OfferName = f.Object.OfferName,
                Duration = f.Object.Duration,
                Offer = f.Object.Offer,
                Description = f.Object.Description,
                Key = f.Key
            })
            .ToList();
        }
    }
}