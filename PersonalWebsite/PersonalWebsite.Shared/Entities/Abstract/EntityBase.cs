using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Shared.Abstract
{
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public virtual bool IsDeleted { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Note { get; set; }
    }
}
