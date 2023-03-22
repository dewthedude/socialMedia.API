using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Shared.ResponseModel
{
    public class PackageMasterResponse
    {
        public Guid CategoryId { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime ModifiedOnUtc { get; set; }
        public string? Icon { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class PackageSubCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Icon { set; get; }   
        public string PackageName { get; set; }
        public bool IsActive { get; set; }    
        public DateTime CreatedOnUtc { get; set; }
        public DateTime ModifiedOnUtc { get; set; }
    }
    public class PackageSubCategoryDropdown
    {
        public Guid SubCategoryId { get; set; }
        public string Name { get; set; }
    }
    public class MasterFeaturesResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Icon { set; get; }    
        public string? SubCategory { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
