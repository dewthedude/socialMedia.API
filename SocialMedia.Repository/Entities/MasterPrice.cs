using CustomForms.Api.Repositories.Entities;
using CustomForms.Api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Repository.Entities
{
    public class MasterPrice : EntityBase<Guid>, IAuditableEntity
    {
        [ForeignKey("SubCategoryId")]
        public virtual MasterSubCategory masterSubCategory { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }  
        public decimal Discount { get; set; }
        public decimal DiscountPrice { get; set; }     
        public bool IsDeleted { get; set; }
        public Guid SubCategoryId { get; set; }
    }
}
