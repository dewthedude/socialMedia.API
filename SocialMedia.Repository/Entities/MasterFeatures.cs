using CustomForms.Api.Repositories.Entities;
using CustomForms.Api.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SocialMedia.Repository.Entities
{
    public class MasterFeatures : EntityBase<Guid>, IAuditableEntity
    {
        [ForeignKey("SubCategoryId")]
        public virtual MasterSubCategory  masterSubCategory { get; set; }
        [StringLength(400)]
        public string Name { get; set; }
        [StringLength(40)]
        public string? Icon { get; set; }
        public bool IsDeleted { get; set; }   
        public bool IsActive { get; set; }
        public Guid SubCategoryId { get; set; }
    }
}
