using PersonalWebsite.Data.Abstract;
using PersonalWebsite.Data.Concrete.EntityFramework.Contexts;
using PersonalWebsite.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonalWebsiteContext _context;
        private IArticleRepository _articleRepository;
        private ICategoryRepository _categoryRepository;
        private ICommentRepository _commentRepository;

        public UnitOfWork(PersonalWebsiteContext context)
        {
            _context = context;
        }

        public IArticleRepository Article => _articleRepository ?? new EfArticleRepository(_context);

        public ICategoryRepository Category => _categoryRepository ?? new EfCategoryRepository(_context);

        public ICommentRepository Comment => _commentRepository ?? new EfCommentRepository(_context);


        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
