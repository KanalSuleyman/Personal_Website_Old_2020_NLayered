﻿using PersonalWebsite.Entities.Concrete;
using PersonalWebsite.Entities.Dtos;
using PersonalWebsite.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> Get(int categoryId);
        Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDto(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAll();
        Task<IDataResult<CategoryListDto>> GetAllByNonDeleted();
        Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto);
        Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto);
        Task<IDataResult<CategoryDto>> Delete(int categoryId);
        Task<IResult> HardDelete(int categoryId);
    }
}
