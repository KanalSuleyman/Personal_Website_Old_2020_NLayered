using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Data.Abstract;
using PersonalWebsite.Entities.Concrete;
using PersonalWebsite.Shared.Data.Abstract;
using PersonalWebsite.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Data.Concrete.EntityFramework.Repositories
{
    public class EfCategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
    {
        public EfCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
