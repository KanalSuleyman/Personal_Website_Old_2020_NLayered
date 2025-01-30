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
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public CategoryManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto)
        {
            if (categoryAddDto != null)
            {
                var category = _mapper.Map<Category>(categoryAddDto);
                if (category != null)
                {
                    var addedCategory = await _unitOfWork.Category.AddAsync(category);
                    await _unitOfWork.SaveAsync();
                    return new DataResult<CategoryDto>(ResultStatus.Success, $"{categoryAddDto.Name} named category added successfully!", new CategoryDto
                    {
                        Category = addedCategory,
                        ResultStatus = ResultStatus.Success,
                        Message = $"{categoryAddDto.Name} named category added successfully!"
                    });
                }
                return new DataResult<CategoryDto>(ResultStatus.Error, "An error occured while mapping the category", new CategoryDto
                {
                    Category = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "An error occured while mapping the category"
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "An error occured while adding the category!", new CategoryDto
            {
                Category = null,
                ResultStatus = ResultStatus.Error,
                Message = "An error occured while adding the category!"
            });
        }

        public async Task<IDataResult<CategoryDto>> Delete(int categoryId)
        {
            var category = await _unitOfWork.Category.GetAsync(c => c.Id == categoryId);

            if (category != null)
            {
                category.IsDeleted = true;
                category.ModifiedDate = DateTime.UtcNow;
                var deletedCategory = await _unitOfWork.Category.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(ResultStatus.Success, $"{deletedCategory.Name} named category deleted succesfully!", new CategoryDto
                {
                    ResultStatus = ResultStatus.Success,
                    Message = $"{deletedCategory.Name} named category deleted succesfully!",
                    Category = deletedCategory
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "There is no such category!", new CategoryDto
            {
                ResultStatus = ResultStatus.Error,
                Message = "There is no such category",
                Category = null
            });
        }

        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var category = await _unitOfWork.Category.GetAsync(c => c.Id == categoryId, c => c.Articles);

            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "There is no categories!", new CategoryDto
            {
                Category = null,
                ResultStatus = ResultStatus.Error,
                Message = "There is no categories!"
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Category.GetAllAsync(null, c => c.Articles);

            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "There is no categories", new CategoryListDto
            {
                Categories = null,
                ResultStatus = ResultStatus.Error,
                Message = "There is no categories"
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleted()
        {
            var categories = await _unitOfWork.Category.GetAllAsync(c => !c.IsDeleted, c => c.Articles);

            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "There is no categories", new CategoryListDto
            {
                Categories = null,
                ResultStatus = ResultStatus.Error,
                Message = "There is no categories"
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive()
        {
            var categories = await _unitOfWork.Category.GetAllAsync(c => !c.IsDeleted && c.IsActive, c => c.Articles);

            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "There is no categories", null);
        }

        public async Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDto(int categoryId)
        {
            var result = await _unitOfWork.Category.AnyAsync(c => c.Id == categoryId);
            if (result)
            {
                var category = await _unitOfWork.Category.GetAsync(c => c.Id == categoryId);
                var categoryUpdateDto = _mapper.Map<CategoryUpdateDto>(category);
                return new DataResult<CategoryUpdateDto>(ResultStatus.Success, categoryUpdateDto);
            }
            else
            {
                return new DataResult<CategoryUpdateDto>(ResultStatus.Error,"There is no such category!" , null);
            }
        }

        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitOfWork.Category.GetAsync(c => c.Id == categoryId);

            if (category != null)
            {
                await _unitOfWork.Category.DeleteAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{category.Name} named category deleted from the database successfully!");
            }
            return new Result(ResultStatus.Error, "Category not found!");
        }

        public async Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto)
        {

            if (categoryUpdateDto != null)
            {
                var oldCategory = await _unitOfWork.Category.GetAsync(c => c.Id == categoryUpdateDto.Id);
                var category = _mapper.Map<CategoryUpdateDto, Category>(categoryUpdateDto, oldCategory);
                if (category != null)
                {
                    var updatedCategory = await _unitOfWork.Category.UpdateAsync(category);
                    await _unitOfWork.SaveAsync();
                    return new DataResult<CategoryDto>(ResultStatus.Success, $"{categoryUpdateDto.Name} named category updated successfully!", new CategoryDto
                    {
                        Category = updatedCategory,
                        ResultStatus = ResultStatus.Success,
                        Message = $"{categoryUpdateDto.Name} named category updated successfully!"
                    });
                }
                return new DataResult<CategoryDto>(ResultStatus.Error, "An error occured while mapping the category", new CategoryDto
                {
                    Category = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "An error occured while mapping the category"
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "An error occured while updating the category!", new CategoryDto
            {
                Category = null,
                ResultStatus = ResultStatus.Error,
                Message = "An error occured while mapping the category"
            });

            //var category = await _unitOfWork.Category.GetAsync(c => c.Id == categoryUpdateDto.Id);

            //if (category != null)
            //{
            //    category.Name = categoryUpdateDto.Name;
            //    category.Description = categoryUpdateDto.Description;
            //    category.Note = categoryUpdateDto.Note;
            //    category.IsActive = categoryUpdateDto.IsActive;
            //    category.IsDeleted = categoryUpdateDto.IsDeleted;
            //    category.ModifiedDate = DateTime.UtcNow;
            //    await _unitOfWork.Category.UpdateAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());
            //    return new Result(ResultStatus.Success, $"{category.Name} named category updated succesfully!");
            //}
            //return new Result(ResultStatus.Error, "Category not found!");
        }
    }
}
