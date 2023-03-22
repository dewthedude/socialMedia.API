using SocialMedia.Repository.Entities;
using SocialMedia.Shared.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Service.Package
{
    public interface IPackageService
    {
        Task<Response<string>> AddCategory(string packageName, string? icon);
        Task<Response<List<PackageMasterResponse>>> GetPackageCategory();
        Task<Response<List<PackageMasterResponse>>> GetCategoryDropdown();
        Task<Response<string>> AddSubCategory(Guid categoryId, string subCategory);
        Task<Response<List<PackageSubCategoryResponse>>> GetPackageSubCategory();
        Task<Response<List<PackageSubCategoryDropdown>>> GetSubCategoryDropdown();
        Task<Response<string>> AddCategoryFeatureAsync(Guid subCategoryId, string name);
        Task<Response<List<MasterFeaturesResponse>>> GetCategoryFeatureListAsync();
        Task<Response<dynamic>> GetPackageListAsync(Guid id);
        Task<Response<bool>> ActivateCategoryAsync(Guid id);
    }
}
