using Microsoft.AspNetCore.Mvc;
using Shared.GoSibu.Models;
using Firebase.Database;
using Firebase.Database.Query;
using GoSibu.WebApi.Models;

namespace GoSibu.WebApi.Controllers
{
    //Attribute, data annotation
    [ApiController]
    [Route("[controller]")]
    //[Authorize("Admin")]
    public class PackageServiceController : ControllerBase
    {
        FirebaseClient firebase = new FirebaseClient(Setting.FireBaseDatabaseUrl, new FirebaseOptions
        {
            AuthTokenAsyncFactory = () => Task.FromResult(Setting.FireBaseSeceret)
        });

        private readonly ILogger<PackageServiceController> _logger;

        public PackageServiceController(ILogger<PackageServiceController> logger)
        {
            _logger = logger;
        }

        [HttpPut(Name = "AddorUpdatePackage")]

        public async Task<bool> AddOrUpdatePackage(PackageModel packageModel)
        {
            if (!string.IsNullOrWhiteSpace(packageModel.Key))
            {
                try
                {
                    await firebase.Child(nameof(PackageModel)).Child(packageModel.Key).PutAsync(packageModel);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                var response = await firebase.Child(nameof(PackageModel)).PostAsync(packageModel);
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

        [HttpDelete(Name = "DeletePackage")]
        public async Task<bool> DeletePackage(string key)
        {
            try
            {
                await firebase.Child(nameof(PackageModel)).Child(key).DeleteAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet(Name = "GetAllPackage")]
        public async Task<List<PackageModel>> GetAllPackage()
        {
            return (await firebase.Child(nameof(PackageModel)).OnceAsync<PackageModel>()).Select(f => new PackageModel
            {
                PackageName = f.Object.PackageName,
                Departure = f.Object.Departure,
                Destination1 = f.Object.Destination1,
                Destination2 = f.Object.Destination2,
                Destination3 = f.Object.Destination3,
                Destination4 = f.Object.Destination4,
                Duration = f.Object.Duration,
                Attention = f.Object.Attention,
                PackagePrice = f.Object.PackagePrice,
                PersonLimit = f.Object.PersonLimit,
                DateandTIme = f.Object.DateandTIme,
                Discription =f.Object.Discription,
                Key = f.Key
            })
            .ToList();
        }
    }
}