using SocialMedia.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Repository.Interfaces
{
    public interface IMasterCategoryRepository
    {
        Task<int> AddPackageCategory(MasterCategory req);
        Task<List<MasterCategory>> GetCategoryListAsync();
        Task<List<MasterCategory>> GetCategoryDropdownAsync();
        Task<MasterCategory> GetCategoryByIdAsync(Guid id);
        Task<int> UpdateCategoryAsync(MasterCategory res);
    }
}
