using CustomForms.Api.Repositories.Entities;
using CustomForms.Api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Repository.Entities
{
    public class MasterSubCategory : EntityBase<Guid>, IAuditableEntity
    {
        public MasterSubCategory()
        {
            masterPrice = new HashSet<MasterPrice>();
            masterFeatures = new HashSet<MasterFeatures>();
        }
        [ForeignKey("CategoryId")]
        public virtual MasterCategory masterCategory { get; set; }    
        [StringLength(400)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Features { get;set; }
        [StringLength(40)]
        public string? Icon { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }   
        public Guid CategoryId { get; set; }
        public ICollection<MasterPrice> masterPrice { get; set; }
        public ICollection<MasterFeatures> masterFeatures { get; set; }
    }
}
