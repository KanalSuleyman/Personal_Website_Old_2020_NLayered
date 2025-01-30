using PersonalWebsite.Entities.Concrete;
using PersonalWebsite.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Data.Abstract
{
    public interface IArticleRepository: IEntityRepository<Article>
    {

    }
}
