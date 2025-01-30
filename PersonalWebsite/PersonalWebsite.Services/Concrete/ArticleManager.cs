using AutoMapper;
using PersonalWebsite.Data.Abstract;
using PersonalWebsite.Entities.Concrete;
using PersonalWebsite.Entities.Dtos;
using PersonalWebsite.Services.Abstract;
using PersonalWebsite.Shared.Utilities.Results.Abstract;
using PersonalWebsite.Shared.Utilities.Results.ComplexTypes;
using PersonalWebsite.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Services.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(ArticleAddDto articleAddDto)
        {
            var article = _mapper.Map<Article>(articleAddDto);
            article.UserId = 1;

            await _unitOfWork.Article.AddAsync(article);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{articleAddDto.Title} titled post added succesfully!");
        }

        public async Task<IResult> Delete(int articleId)
        {
            var article = await _unitOfWork.Article.GetAsync(a => a.Id == articleId);

            if (article != null)
            {
                article.IsDeleted = true;
                article.ModifiedDate = DateTime.UtcNow;
                await _unitOfWork.Article.UpdateAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{article.Title} titled article deleted successfully!");
            }
            return new Result(ResultStatus.Error, "Article not found!");
        }

        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Article.GetAsync(a => a.Id == articleId, ar => ar.Category, ar => ar.User);

            if(article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, "Article not found!", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitOfWork.Article.GetAllAsync(null, a => a.Category, a => a.User);
            
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Articles not found!", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var result = await _unitOfWork.Category.AnyAsync(c => c.Id == categoryId);
            
            if (result)
            {
                var articles = await _unitOfWork.Article.GetAllAsync(a => a.CategoryId == categoryId, ar => ar.Category, ar => ar.User);

                if (articles != null)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success
                    });
                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, "There is no articles in this category!", null);
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Category not found!", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await _unitOfWork.Article.GetAllAsync(a => a.IsDeleted == false, a => a.Category, a => a.User);

            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Articles not found!", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles = await _unitOfWork.Article.GetAllAsync(a => !a.IsDeleted && a.IsActive, a => a.Category, a => a.User);

            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Articles not found!", null);
        }

        public async Task<IResult> HardDelete(int articleId)
        {
            var article = await _unitOfWork.Article.GetAsync(a => a.Id == articleId);

            if (article != null)
            {
                await _unitOfWork.Article.DeleteAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{article.Title} titled article deleted from the database successfully!");
            }
            return new Result(ResultStatus.Error, "Article not found!");
        }

        public async Task<IResult> Update(ArticleUpdateDto articleUpdateDto)
        {
            var article = _mapper.Map<Article>(articleUpdateDto);
            await _unitOfWork.Article.UpdateAsync(article);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{articleUpdateDto.Title} titled post updated successfully!");
        }
    }
}
