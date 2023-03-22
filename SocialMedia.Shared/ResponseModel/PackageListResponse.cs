using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Shared.ResponseModel
{
    public class PackageListResponse
    {
        public string PackageId { get; set; }   
        public string Name { get; set; }
        public string Features { get; set; } 
        public string Description { get; set; }
    }
}
