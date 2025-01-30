using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Entities.Dtos
{
    public class UserAddDto
    {
        [DisplayName("User Name")]
        [Required(ErrorMessage = "{0} Field Can Not Be Empty")]
        [MaxLength(50, ErrorMessage = "{0} Can Not Be More Than {1} Characters")]
        [MinLength(3, ErrorMessage = "{0} Can Not Be Less Than {1} Characters")]
        public string UserName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} Field Can Not Be Empty")]
        [MaxLength(100, ErrorMessage = "{0} Can Not Be More Than {1} Characters")]
        [MinLength(10, ErrorMessage = "{0} Can Not Be Less Than {1} Characters")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "{0} Field Can Not Be Empty")]
        [MaxLength(30, ErrorMessage = "{0} Can Not Be More Than {1} Characters")]
        [MinLength(6, ErrorMessage = "{0} Can Not Be Less Than {1} Characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Picture")]
        [Required(ErrorMessage = "{0} Field Can Not Be Empty")]
        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }

        public string PictureFileName { get; set; }
    }
}
