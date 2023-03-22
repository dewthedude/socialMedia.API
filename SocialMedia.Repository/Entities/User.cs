using CustomForms.Api.Repositories.Entities;
using CustomForms.Api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Repository.Entities
{
    public class User : EntityBase<Guid>, IAuditableEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
