using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Controllers.PackageController.DTO;
using SocialMedia.Repository.Entities;
using SocialMedia.Service.Services.Master;
using SocialMedia.Shared.ResponseModel;

namespace SocialMedia.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterService _masterService;
        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;
        }
        [HttpGet]
        [Route("{id}/categorybyId")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var res = await _masterService.GetCategoryById(id);
            if (res.Succeeded)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet]
        [Route("subcategory")]
        public async Task<ActionResult<Response<MasterSubCategory>>> GetAllSubCategory()
        {
            var res = await _masterService.GetPackageSubCategory();
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
            var res = await _masterService.AddCategory(req.Name, req.Icon);

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
            var res = await _masterService.GetCategoryDropdown();
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
            var res = await _masterService.GetSubCategoryDropdown();
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
            var res = await _masterService.AddSubCategory(req.CategoryId, req.SubCategory,req.Icon);
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
            var res = await _masterService.AddCategoryFeatureAsync(req.SubCategoryId, req.Name, req.Icon);
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
            var res = await _masterService.GetCategoryFeatureListAsync();
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
                var res = await _masterService.ActivateCategoryAsync(id);
                if (res.Succeeded)
                {
                    return Ok(res);

                }
                return BadRequest(res);
            }
            return BadRequest();
        }
        [HttpPatch]
        [Route("{id}/activatefeature")]
        public async Task<IActionResult> ActivateFeature(Guid id)
        {
            if (id != Guid.Empty)
            {
                var res = await _masterService.ActivateFeatureAsync(id);
                if (res.Succeeded)
                {
                    return Ok(res);

                }
                return BadRequest(res);
            }
            return BadRequest();
        }
        
        [HttpPatch]
        [Route("{id}/subcategoryactivate")]
        public async Task<IActionResult> ActivateSubCategory(Guid id)
        {
            if (id != Guid.Empty)
            {
                var res = await _masterService.ActivateSubCategoryAsync(id);
                if (res.Succeeded)
                {
                    return Ok(res);

                }
                return BadRequest(res);
            }
            return BadRequest();
        }
    }
}
