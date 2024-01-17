using EFIntro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExamination
{
    public class Post
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Blog Blog { get; set; }
        public int? BlogId { get; set; }
        public DateOnly? PublishedOn { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
