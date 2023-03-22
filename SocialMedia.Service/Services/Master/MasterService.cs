using SocialMedia.Repository.Entities;
using SocialMedia.Repository.Interfaces;
using SocialMedia.Service.CommonModels;
using SocialMedia.Shared.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Service.Services.Master
{
    public class MasterService: IMasterService
    {
        private readonly IMasterCategoryRepository _packageCategoryRepository;
        private readonly IMasterSubCategoryRepository _masterSubCategoryRepository;
        private readonly IMasterFeatureRepository _masterFeatureRepository;
        public MasterService(IMasterCategoryRepository packageCategoryRepository, IMasterSubCategoryRepository masterSubCategoryRepository, IMasterFeatureRepository masterFeatureRepository)
        {
            _packageCategoryRepository = packageCategoryRepository;
            _masterSubCategoryRepository = masterSubCategoryRepository;
            _masterFeatureRepository = masterFeatureRepository;
        }
        int i = 0;
        public async Task<Response<string>> AddCategory(string packageName, string icon)
        {
            var isExist = await _packageCategoryRepository.CategoryNameExist(packageName);
            if (isExist)
            {
                return new Response<string>
                {
                    Message = packageName + " " + ResponseMessage.AlreadyExist,
                    Succeeded = false
                };
            }
            MasterCategory packageCategory = new MasterCategory
            {
                Name = packageName,
                CreatedOnUtc = DateTime.Now,
                Description = packageName,
                Id = Guid.NewGuid(),
                Icon = icon,
                IsActive = false,
                IsDeleted = false,
                ModifiedOnUtc = DateTime.Now,
            };
            int res = await _packageCategoryRepository.AddPackageCategory(packageCategory);
            if (res > 0)
            {
                return new Response<string>
                {
                    Succeeded = true,
                    Message = ResponseMessage.AddedSuccess,
                };
            }
            return new Response<string>
            {
                Succeeded = false,
                Message = ResponseMessage.Error
            };
        }
        public async Task<Response<string>> AddCategoryFeatureAsync(Guid subCategoryId, string name,string icon)
        {
            bool isExist = await _masterSubCategoryRepository.ExistSubCategoryId(subCategoryId);
            if (!isExist)
            {
                return new Response<string>
                {
                    Succeeded = false,
                    Message = ResponseMessage.InvalidId
                };
            }
            MasterFeatures req = new MasterFeatures
            {
                Name = name,
                CreatedOnUtc = DateTime.Now,
                Id = Guid.NewGuid(),
                IsActive = false,
                IsDeleted = false,
                ModifiedOnUtc = DateTime.Now,
                SubCategoryId = subCategoryId,
                Icon= icon
            };

            var res = await _masterFeatureRepository.AddMaasterFeatureAsync(req);

            if (res > 0)
            {
                return new Response<string>
                {
                    Succeeded = true,
                    Message = ResponseMessage.AddedSuccess,
                };
            }
            return new Response<string>
            {
                Succeeded = false,
                Message = ResponseMessage.Error
            };
        }
        public async Task<Response<string>> AddSubCategory(Guid categoryId, string subCategory,string icon)
        {

            MasterSubCategory _subCategory = new MasterSubCategory
            {
                CategoryId = categoryId,
                CreatedOnUtc = DateTime.Now,
                Id = Guid.NewGuid(),
                IsDeleted = false,
                IsActive = false,
                ModifiedOnUtc = DateTime.Now,
                Features = "Okay",
                Name = subCategory,
                Icon = icon
            };
            int i = await _masterSubCategoryRepository.AddPackageSubCategory(_subCategory);
            if (i > 0)
            {
                return new Response<string>
                {
                    Succeeded = true,
                    Message = ResponseMessage.AddedSuccess,
                };
            }
            return new Response<string>
            {
                Succeeded = false,
                Message = ResponseMessage.Error,
            };
        }
        public async Task<Response<List<PackageMasterResponse>>> GetCategoryDropdown()
        {
            var res = await _packageCategoryRepository.GetCategoryDropdownAsync();
            if (res.Count > 0)
            {
                return new Response<List<PackageMasterResponse>>
                {
                    Count = res.Count,
                    Data = res.Select(x => new PackageMasterResponse
                    {
                        CategoryId = x.Id,
                        Name = x.Name,
                    }).ToList(),
                    Message = ResponseMessage.RecordFound,
                    Succeeded = true
                };
            }
            return new Response<List<PackageMasterResponse>>
            {
                Message = ResponseMessage.NoRecordFound,
                Succeeded = false
            };
        }
        public async Task<Response<List<MasterFeaturesResponse>>> GetCategoryFeatureListAsync()
        {
            var res = await _masterFeatureRepository.GetCategoryFutureListAsync();

            var filterData = res.Where(x => x.IsDeleted == false).Select(x => new MasterFeaturesResponse
            {
                CreatedDate = x.CreatedOnUtc,
                Id = x.Id,
                Name = x.Name,
                IsActive = x.IsActive,  
                SubCategory = x.masterSubCategory.Name,
                UpdateDate = x.ModifiedOnUtc,
                Icon = x.Icon,
               
            }).ToList();
            if (res.Count > 0)
            {
                return new Response<List<MasterFeaturesResponse>>
                {
                    Count = res.Count,
                    Data = filterData,
                    Message = ResponseMessage.RecordFound,
                    Succeeded = true
                };
            }
            else if (res.Count == 0)
            {
                return new Response<List<MasterFeaturesResponse>>
                {
                    Count = 0,
                    Succeeded = true,
                    Message = ResponseMessage.NoRecordFound

                };
            }
            return new Response<List<MasterFeaturesResponse>>
            {
                Count = 0,
                Message = ResponseMessage.Error,
                Succeeded = false
            };
        }

        public async Task<Response<List<PackageSubCategoryResponse>>> GetPackageSubCategory()
        {
            var res = await _masterSubCategoryRepository.GetSubCategoryAsync();
            var filterData = res.Select(x => new PackageSubCategoryResponse
            {
                Id = x.Id,
                CreatedOnUtc = x.CreatedOnUtc,
                Name = x.Name,
                PackageName = x.masterCategory.Name,
                ModifiedOnUtc = x.ModifiedOnUtc,
                Icon = x.Icon,
                IsActive= x.IsActive
                
            }).ToList();
            if (filterData.Count > 0)
            {
                return new Response<List<PackageSubCategoryResponse>>
                {
                    Message = ResponseMessage.RecordFound,
                    Succeeded = true,
                    Data = filterData
                };
            }
            return new Response<List<PackageSubCategoryResponse>>
            {
                Message = ResponseMessage.NoRecordFound,
                Succeeded = false
            };
        }
        public async Task<Response<List<PackageSubCategoryDropdown>>> GetSubCategoryDropdown()
        {
            var res = await _masterSubCategoryRepository.GetSubCategoryDropdownAsync();
            if (res.Count > 0)
            {
                return new Response<List<PackageSubCategoryDropdown>>
                {
                    Message = ResponseMessage.RecordFound,
                    Succeeded = true,
                    Data = res.Select(x => new PackageSubCategoryDropdown
                    {
                        Name = x.Name,
                        SubCategoryId = x.Id,

                    }).ToList(),
                    Count = res.Count
                };
            }
            return new Response<List<PackageSubCategoryDropdown>>
            {
                Message = ResponseMessage.NoRecordFound,
                Succeeded = false,
            };
        }

        public async Task<Response<bool>> ActivateCategoryAsync(Guid id)
        {
            var res = await _packageCategoryRepository.GetCategoryByIdAsync(id);
            if (res is not null)
            {
                if (res.IsActive)
                {
                    res.IsActive = false;
                }
                else
                {
                    res.IsActive = true;
                }
                i = await _packageCategoryRepository.UpdateCategoryAsync(res);
                if (i > 0)
                {
                    return new Response<bool>
                    {
                        Message = res.Name + " " + ResponseMessage.UpdateSuccess,
                        Succeeded = true,

                    };
                }
                return new Response<bool>
                {
                    Succeeded = false,
                    Message = ResponseMessage.UpdateFailed
                };

            }
            return new Response<bool> { Message = ResponseMessage.InvalidId, Succeeded = false };
        }

        public async Task<Response<CategoryResponse>> GetCategoryById(Guid id)
        {
            var res = await _packageCategoryRepository.GetCategoryByIdAsync(id);
            if (res is not null)
            {
                return new Response<CategoryResponse>
                {
                    Message = ResponseMessage.RecordFound,
                    Data = new CategoryResponse
                    {
                        Category = res.Name,
                        Icon = res.Icon
                    },
                    Succeeded = true,
                };
            }
            return new Response<CategoryResponse>
            {
                Message = ResponseMessage.NoRecordFound,
                Succeeded = false,
            };
        }

        public async Task<Response<bool>> ActivateFeatureAsync(Guid id)
        {
            var res = await _masterFeatureRepository.GetFeatrueById(id);
            if (res is not null)
            {
                if (res.IsActive)
                {
                    res.IsActive = false;
                }
                else
                {
                    res.IsActive = true;
                }
                i = await _masterFeatureRepository.UpdateFeatureAsync(res);
                if (i > 0)
                {
                    return new Response<bool>
                    {
                        Message = res.Name + " " + ResponseMessage.UpdateSuccess,
                        Succeeded = true,

                    };
                }
                return new Response<bool>
                {
                    Succeeded = false,
                    Message = ResponseMessage.UpdateFailed
                };

            }
            return new Response<bool> { Message = ResponseMessage.InvalidId, Succeeded = false };
        }

        public async Task<Response<dynamic>> ActivateSubCategoryAsync(Guid id)
        {

            var res = await _masterSubCategoryRepository.GetSubCategoryById(id);
            if (res is not null)
            {
                if (res.IsActive)
                {
                    res.IsActive = false;
                }
                else
                {
                    res.IsActive = true;
                }
                i = await _masterSubCategoryRepository.UpdateSubCategoryAsync(res);
                if (i > 0)
                {
                    return new Response<dynamic>
                    {
                        Message = res.Name + " " + ResponseMessage.UpdateSuccess,
                        Succeeded = true,

                    };
                }
                return new Response<dynamic>
                {
                    Succeeded = false,
                    Message = ResponseMessage.UpdateFailed
                };

            }
            return new Response<dynamic> { Message = ResponseMessage.InvalidId, Succeeded = false };
        }
       

    }
}
