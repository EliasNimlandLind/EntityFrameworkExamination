using EFIntro;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExamination
{
    public class Blog
    {
            public int? Id { get; set; }
            public string? URL { get; set; }
            public string? Name { get; set; }
            public List<int> PostIds { get; set; }
        }
}
