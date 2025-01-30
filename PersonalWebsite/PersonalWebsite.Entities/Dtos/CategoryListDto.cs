using PersonalWebsite.Entities.Concrete;
using PersonalWebsite.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Entities.Dtos
{
    public class CategoryListDto: DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}
