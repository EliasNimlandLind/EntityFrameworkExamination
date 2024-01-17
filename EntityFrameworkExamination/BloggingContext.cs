using EFIntro;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExamination
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        private string _databasePath { get; }
        public BloggingContext()
        {
            Environment.SpecialFolder folder = Environment.SpecialFolder.ApplicationData;
            string path = AppDomain.CurrentDomain.BaseDirectory;
            _databasePath = Path.Join(path, "cs.forts-elias-nimland-lind.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source = {_databasePath}");
        }
    }
}
