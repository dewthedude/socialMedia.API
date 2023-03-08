using CustomForms.Api.Repositories.Interfaces;
using CustomForms.Api.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Repository.EF.Context;
using SocialMedia.Repository.Entities;
using SocialMedia.Repository.Interfaces;


namespace SocialMedia.Repository.Repository
{
    public class MasterCategoryRepository : BaseRepository<MasterCategoryRepository>, IMasterCategoryRepository
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;
        int i = 0;
        public MasterCategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = (AppDbContext)_unitOfWork.Db;
        }

        public async Task<int> AddPackageCategory(MasterCategory req)
        {
            await _context.MasterCategory.AddAsync(req);
            i = await _context.SaveChangesAsync();
            return i;
        }



        public async Task<List<MasterCategory>> GetCategoryListAsync()
        {
            var res = (dynamic)null;
            try
            {
                res = await _context.MasterCategory.Where(x => x.IsDeleted == false).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
            }
            return res;
        }

        public async Task<List<MasterCategory>> GetCategoryDropdownAsync()
        {
            try
            {
                return await _context.MasterCategory.Where(x => x.IsActive == true && x.IsDeleted == false).AsNoTracking().ToListAsync();
            }
            catch (Exception ex) { }
            return null;
        }

        public async Task<MasterCategory> GetCategoryByIdAsync(Guid id)
        {
            return await _context.MasterCategory.FindAsync(id);
        }

        public async Task<int> UpdateCategoryAsync(MasterCategory res)
        {
            _context.MasterCategory.Update(res);
            i = await _context.SaveChangesAsync();
            return i;
        }

        public async Task<bool> CategoryNameExist(string packageName)
        {
            return await _context.MasterCategory.AnyAsync(x => x.Name.ToLower() == packageName.ToLower() && x.IsDeleted == false);
        }
    }
}
