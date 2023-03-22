using SocialMedia.Shared.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Service.Services.Master
{
    public interface IMasterService
    {
        Task<Response<string>> AddCategory(string packageName, string? icon);

        Task<Response<List<PackageMasterResponse>>> GetCategoryDropdown();
        Task<Response<string>> AddSubCategory(Guid categoryId, string subCategory,string icon);
        Task<Response<List<PackageSubCategoryResponse>>> GetPackageSubCategory();
        Task<Response<List<PackageSubCategoryDropdown>>> GetSubCategoryDropdown();
        Task<Response<string>> AddCategoryFeatureAsync(Guid subCategoryId, string name,string icon);
        Task<Response<List<MasterFeaturesResponse>>> GetCategoryFeatureListAsync();
        Task<Response<bool>> ActivateCategoryAsync(Guid id);
        Task<Response<CategoryResponse>> GetCategoryById(Guid id);
        Task<Response<bool>> ActivateFeatureAsync(Guid id);
        Task<Response<dynamic>> ActivateSubCategoryAsync(Guid id);
    }
}
