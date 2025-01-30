using PersonalWebsite.Entities.Concrete;
using PersonalWebsite.Entities.Dtos;
using PersonalWebsite.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Services.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<ArticleDto>> Get(int articleId);
        Task<IDataResult<ArticleListDto>> GetAll();
        Task<IDataResult<ArticleListDto>> GetAllByNonDeleted();
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId);
        Task<IResult> Add(ArticleAddDto articleAddDto);
        Task<IResult> Update(ArticleUpdateDto articleUpdateDto);
        Task<IResult> Delete(int articleId);
        Task<IResult> HardDelete(int articleId);
    }
}
