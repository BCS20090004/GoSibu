using Shared.GoSibu.Models;

namespace AdminPanelGoSibu.Services
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

        public Task<bool> DeletePackage(PackageModel packageModel)
        {
            return DeleteAsync($"PackageService?key={packageModel.Key}");
        }
    }
}
