using CustomForms.Api.Repositories.Interfaces;
using CustomForms.Api.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Repository.EF.Context;
using SocialMedia.Repository.Entities;
using SocialMedia.Repository.Interfaces;

namespace SocialMedia.Repository.Repositories
{
    public class MasterFeatureRepository : BaseRepository<MasterFeatureRepository>, IMasterFeatureRepository
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;
        int i = 0;
        public MasterFeatureRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = (AppDbContext)_unitOfWork.Db;
        }


        public async Task<int> AddMaasterFeatureAsync(MasterFeatures req)
        {
            await _context.MasterFeature.AddAsync(req);
            i = await _context.SaveChangesAsync();
            return i;
        }

        public async Task<List<MasterFeatures>> GetCategoryFutureListAsync()
        {
            return await _context.MasterFeature.Include(x => x.masterSubCategory).ToListAsync();
        }

        public async Task<List<MasterFeatures>> GetPackageDetails()
        {
            var res = await _context.MasterFeature.Include(x => x.masterSubCategory).ThenInclude(a => a.masterCategory).ToListAsync();
            return res;
        }
    }
}
