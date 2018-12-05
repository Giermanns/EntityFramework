﻿using System;
using System.Linq;

namespace ConsoleApp.NewDb
{
    class Program
    {
        public void Main(string[] args)
        {
            Boolean run = false;
            int caseSwitch = 0;
            int id = 9;
            string titel = string.Empty;
            string content = string.Empty;
            int blogId = 0;
            string url = string.Empty;
            //Console.WriteLine(url);
            while (run)
            {
                Console.WriteLine("Entity Framework");
                Console.WriteLine("------------------------");
                Console.WriteLine("Insert");
                Console.WriteLine("Delet");
                if (int.TryParse(Console.ReadLine(), out caseSwitch) && caseSwitch <= 3 && caseSwitch != 0)
                {
                    Console.Clear();
                }
                switch (caseSwitch)
                {
                    case 1:
                        break;
                }

                //Add Blog
                using (var db = new BloggingContext())
                {
                    db.Blogs.Add(new Blog { Url = $"{url}" });
                    var count = db.SaveChanges();
                    Console.WriteLine($"{count} records saved to database");
                    Console.WriteLine();
                    Console.WriteLine("All blogs in database:");
                    foreach (var blog in db.Blogs)
                    {
                        Console.WriteLine($" - {blog.Url}");
                    }
                    Console.WriteLine("Press a Key to Exit!");
                    Console.ReadKey();
                    run = false;
                }
                //Add Post
                using (var db = new BloggingContext())
                {
                    db.Posts.Add(new Post { Title = $"{titel}", Content = $"{content}", BlogId = blogId });
                    var count = db.SaveChanges();
                    Console.WriteLine($"{count} records saved to database");
                    Console.WriteLine();
                    Console.WriteLine("Post in database");
                    foreach (var post in db.Posts)
                    {
                        Console.WriteLine($" - {post.Title}", $" - {post.Content}", $" - {post.BlogId}");
                    }
                    Console.WriteLine("Press a Key to Exit!");
                    Console.ReadKey();
                    run = false;
                }
                //Remove Blog with BlogId
                var removeUrl = new Blog() { BlogId = id };
                using (var context = new BloggingContext())
                {
                    context.Blogs.Attach(removeUrl);
                    context.Blogs.Remove(removeUrl);
                    context.SaveChanges();
                }
            }
        }
    }
}