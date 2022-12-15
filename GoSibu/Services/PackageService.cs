using Gosibu.Shared.Models;

namespace GoSibu.Services
{
    public class PackageService : BaseApiService
    {
        public Task<List<PackageModel>> GetAllPackage()
        {

            return GetTAsync<List<PackageModel>>("PackageService");
        }

        public Task<HttpResponseMessage> AddOrUpdatePackage(PackageModel packageModel)
        {
            return PutAsync("PackageService", packageModel);
        }

    }
}
