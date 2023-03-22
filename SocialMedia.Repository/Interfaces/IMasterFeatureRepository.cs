using SocialMedia.Repository.Entities;
using SocialMedia.Shared.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Repository.Interfaces
{
    public interface IMasterFeatureRepository
    {
        Task<int> AddMaasterFeatureAsync(MasterFeatures req);
        Task<List<MasterFeatures>> GetCategoryFutureListAsync();
        Task<List<MasterFeatures>> GetPackageDetails();
    }
}
