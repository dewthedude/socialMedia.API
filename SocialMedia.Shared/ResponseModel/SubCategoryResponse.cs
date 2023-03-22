using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Shared.ResponseModel
{
    public class SubCategoryResponse
    {
        public string Name { get; set; }
        public string Features { get; set; }
        public string IsDeleted { get; set; }
        public Guid CategoryId { get; set; }
    }
}
