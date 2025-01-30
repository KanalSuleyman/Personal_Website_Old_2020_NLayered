using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Entities.Dtos
{
    public class CategoryUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Category Name")]
        [Required(ErrorMessage = "{0} Field Can Not Be Empty")]
        [MaxLength(70, ErrorMessage = "{0} Can Not Be More Than {1} Characters")]
        [MinLength(3, ErrorMessage = "{0} Can Not Be Less Than {1} Characters")]
        public string Name { get; set; }

        [DisplayName("Category Description")]
        [MaxLength(308, ErrorMessage = "{0} Can Not Be More Than {1} Characters")]
        public string Description { get; set; }

        [DisplayName("Admin Note For The Category")]
        [MaxLength(469, ErrorMessage = "{0} Can Not Be More Than {1} Characters")]
        public string Note { get; set; }

        [DisplayName("Category Visibility")]
        [Required(ErrorMessage = "{0} Field Can Not Be Empty")]
        public bool IsActive { get; set; }

        [DisplayName("Category Existance")]
        [Required(ErrorMessage = "{0} Field Can Not Be Empty")]
        public bool IsDeleted { get; set; }


    }
}
