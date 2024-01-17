using EFIntro;
using EntityFrameworkExamination;
using System;

class Program
{
    static void Main()
    {
        using (BloggingContext bloggingContext = new BloggingContext())
        {
            ObjectReader objectReader = new ObjectReader();
            objectReader.BloggingContext = bloggingContext;

            objectReader.AddBlogs();
            objectReader.AddUsers();
            objectReader.AddPosts();
            bloggingContext.SaveChanges();

            Console.WriteLine(objectReader.ToString());
        }
    }
}