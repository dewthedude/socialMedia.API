using CustomForms.Api.Repositories.Interfaces;
using CustomForms.Api.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Repository.EF.Context;
using SocialMedia.Repository.Entities;
using SocialMedia.Repository.Interfaces;
using SocialMedia.Shared.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Repository.Repositories
{
    public class MasterSubCategoryRepository:BaseRepository<MasterSubCategoryRepository>, IMasterSubCategoryRepository
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;
        int i = 0;
        public MasterSubCategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = (AppDbContext)_unitOfWork.Db;
        }

        public async Task<int> AddPackageSubCategory(MasterSubCategory req)
        {
            await _context.MasterSubCategory.AddAsync(req);
            i = await _context.SaveChangesAsync();
            return i;
        }
        public async Task<List<MasterSubCategory>> GetSubCategoryAsync()
        {
            return await _context.MasterSubCategory.Include(c => c.masterCategory).ToListAsync();
        }
        public async Task<List<MasterSubCategory>> GetSubCategoryDropdownAsync()
        {
            return await _context.MasterSubCategory.Where(x => x.IsActive == true && x.IsDeleted == false).AsNoTracking().ToListAsync();
        }
        public async Task<bool> ExistSubCategoryId(Guid Id)
        {
            return await _context.MasterSubCategory.AnyAsync(x => x.Id == Id);
        }
    }
}
