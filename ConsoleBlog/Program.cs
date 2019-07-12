using System;

namespace ConsoleBlog
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                db.Database.EnsureCreated();
                var blog = new Blog { Url = "http://sample.com" };
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
            using (var db = new BloggingContext())
            {
                var result = db.Blogs;
                foreach(var blog in result)
                {
                    Console.Out.WriteLine($"Blog Id: {blog.BlogId}");
                    Console.Out.WriteLine($"Blog Url: {blog.Url}");
                    Console.Out.WriteLine($"Blog Rating: {blog.Rating}");
                    Console.Out.WriteLine($"--------");
                }
            }
        }
    }
}
