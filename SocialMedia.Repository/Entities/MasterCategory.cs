using CustomForms.Api.Repositories.Entities;
using CustomForms.Api.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;


namespace SocialMedia.Repository.Entities
{
    public class MasterCategory : EntityBase<Guid>, IAuditableEntity
    {
        public MasterCategory()
        {
            masterSubCategory = new HashSet<MasterSubCategory>();
        }
        [StringLength(400)]
        public string? Name { get; set; }
        [StringLength(40)]
        public string? Icon { get; set; }
        [StringLength(2000)]
        public string? Description { get; set; } 
        public bool IsActive { get; set; }  
        public bool IsDeleted { get; set; }
       
        public ICollection<MasterSubCategory> masterSubCategory { get; set; }
    }
}
