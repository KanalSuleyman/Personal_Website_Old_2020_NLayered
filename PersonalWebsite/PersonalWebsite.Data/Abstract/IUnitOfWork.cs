using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Data.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IArticleRepository Article { get; }
        ICategoryRepository Category { get; }
        ICommentRepository Comment { get; }
        Task<int> SaveAsync();
    }
}
