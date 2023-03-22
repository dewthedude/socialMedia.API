using SocialMedia.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Repository.Interfaces
{
    public interface IMasterSubCategoryRepository
    {
        Task<int> AddPackageSubCategory(MasterSubCategory req);
        Task<List<MasterSubCategory>> GetSubCategoryAsync();
        Task<List<MasterSubCategory>> GetSubCategoryDropdownAsync();
        Task<bool> ExistSubCategoryId(Guid Id);

    }
}
