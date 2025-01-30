using PersonalWebsite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Entities.Dtos
{
    public class ArticleUpdateDto
    {
        [Required]
        public int ArticleId { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "{0} field can not be empty!")]
        [MaxLength(98, ErrorMessage = "{0} field can not be more than {1} characters!")]
        [MinLength(7, ErrorMessage = "{0} field can not be less than {1} characters!")]
        public string Title { get; set; }

        [DisplayName("Content")]
        [Required(ErrorMessage = "{0} field can not be empty!")]
        [MinLength(21, ErrorMessage = "{0} field can not be less than {1} characters!")]
        public string Content { get; set; }

        [DisplayName("Thumbnail")]
        [Required(ErrorMessage = "{0} field can not be empty!")]
        [MaxLength(245, ErrorMessage = "{0} field can not be more than {1} characters!")]
        [MinLength(7, ErrorMessage = "{0} field can not be less than {1} characters!")]
        public string Thumbnail { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "{0} field can not be empty!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "(0:dd/MM/yyyy)")]
        public DateTime Date { get; set; }

        [DisplayName("Seo Author")]
        [Required(ErrorMessage = "{0} field can not be empty!")]
        [MaxLength(49, ErrorMessage = "{0} field can not be more than {1} characters!")]
        [MinLength(0, ErrorMessage = "{0} field can not be less than {1} characters!")]
        public string SeoAuthor { get; set; }

        [DisplayName("Seo Description")]
        [Required(ErrorMessage = "{0} field can not be empty!")]
        [MaxLength(147, ErrorMessage = "{0} field can not be more than {1} characters!")]
        [MinLength(0, ErrorMessage = "{0} field can not be less than {1} characters!")]
        public string SeoDescription { get; set; }

        [DisplayName("Seo Author")]
        [Required(ErrorMessage = "{0} field can not be empty!")]
        [MaxLength(312, ErrorMessage = "{0} field can not be more than {1} characters!")]
        [MinLength(0, ErrorMessage = "{0} field can not be less than {1} characters!")]
        public string SeoTags { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "{0} field can not be empty!")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [DisplayName("Visibility")]
        [Required(ErrorMessage = "{0} field can not be empty!")]
        public bool IsActive { get; set; }

        [DisplayName("Existance")]
        [Required(ErrorMessage = "{0} field can not be empty!")]
        public bool IsDeleted { get; set; }
    }
}
