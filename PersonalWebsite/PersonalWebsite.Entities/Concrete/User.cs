using Microsoft.AspNetCore.Identity;
using PersonalWebsite.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Entities.Concrete
{
    public class User: IdentityUser<int>
    {
        public string PictureFileName { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
