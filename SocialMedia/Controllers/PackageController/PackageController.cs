using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Controllers.PackageController.DTO;
using SocialMedia.Repository.Entities;
using SocialMedia.Service.Services.Package;
using SocialMedia.Shared.ResponseModel;
namespace SocialMedia.Controllers.PackageController
{
    [Route("api/package")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        public readonly IPackageService _packageService;
        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;

        }

        [HttpGet]
        [Route("packagelist")]
        public async Task<ActionResult<Response<string>>> GetPackagesList(Guid Id)
        {
            var res = await _packageService.GetPackageListAsync(Id);

            if (res.Succeeded)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<Response<PackageMasterResponse>>> GetCategoryList()   
        {
            var res = await _packageService.GetPackageCategory();
            if (res.Succeeded)
            {
                return Ok(res);
            }
            else if (res.Message.Contains("No record found"))
            {
                return NoContent();
            }
            return BadRequest(res);

        }
    }
}
