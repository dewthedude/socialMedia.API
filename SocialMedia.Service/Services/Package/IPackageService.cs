using SocialMedia.Repository.Entities;
using SocialMedia.Shared.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Service.Services.Package
{
    public interface IPackageService
    {

        Task<Response<dynamic>> GetPackageListAsync(Guid id);
        Task<Response<List<PackageMasterResponse>>> GetPackageCategory();

    }
}
