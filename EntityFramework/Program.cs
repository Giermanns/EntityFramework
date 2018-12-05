using System;
using System.Linq;

namespace ConsoleApp.NewDb
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                db.Blogs.Add(new Blog { Url = "https://blogs.msdn.microsoft.com/adonet/page/2/" });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);
                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine($" - {blog.Url}");
                }
                Console.WriteLine("Press a Key to Exit!");
                Console.ReadKey();
            }
        }
    }
}