using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Controllers.PackageController.DTO;
using SocialMedia.Repository.Entities;
using SocialMedia.Service.Package;
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
        public async Task<ActionResult<Response<PackageMasterResponse>>> GetAllPackage()
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

        [HttpGet]
        [Route("subcategory")]
        public async Task<ActionResult<Response<MasterSubCategory>>> GetAllSubCategory()
        {
            var res = await _packageService.GetPackageSubCategory();
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


        [HttpPost]
        public async Task<ActionResult<Response<string>>> AddCategory([FromForm] CategoryModel req, CancellationToken cancellationToken)
        {
            var res = await _packageService.AddCategory(req.Name);

            if (res.Succeeded)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet]
        [Route("categorydropdown")]
        public async Task<ActionResult<Response<PackageMasterResponse>>> GetCategoryDropDown()
        {
            var res = await _packageService.GetCategoryDropdown();
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

        [HttpGet]
        [Route("subcategorydropdown")]
        public async Task<ActionResult<Response<PackageMasterResponse>>> GetSubCategoryDropDown()
        {
            var res = await _packageService.GetSubCategoryDropdown();
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

        [HttpPost]
        [Route("subcategory")]
        public async Task<ActionResult<Response<SubCategoryModel>>> AddSubCategory([FromForm] SubCategoryModel req, CancellationToken cancellationToken)
        {
            var res = await _packageService.AddSubCategory(req.CategoryId, req.SubCategory);
            if (res.Succeeded)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPost]
        [Route("categoryfeature")]
        public async Task<ActionResult<Response<string>>> AddCategoryFeature([FromForm] CategoryFeatureMode req)
        {
            var res = await _packageService.AddCategoryFeatureAsync(req.SubCategoryId, req.Name);
            if (res.Succeeded)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
        [HttpGet]
        [Route("getfeature")]
        public async Task<ActionResult<Response<List<MasterFeaturesResponse>>>> GetCategoryFeaturesList()
        {
            var res = await _packageService.GetCategoryFeatureListAsync();
            if (res.Succeeded)
            {
                if (res.Count > 0)
                {
                    return Ok(res);
                }
                return NoContent();
            }
            return BadRequest(res);
        }

        [HttpPatch]
        [Route("{id}/activate")]
        public async Task<IActionResult> ActivateCategory(Guid id)
        {
            if (id != Guid.Empty)
            {
                var res = await _packageService.ActivateCategoryAsync(id);
                if(res.Succeeded)
                {
                    return Ok(res);

                }
                return BadRequest(res);
            }
            return BadRequest();
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
    }
}
