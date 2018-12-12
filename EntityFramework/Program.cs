using System;

namespace ConsoleApp.NewDb
{
    public class Program
    {
        Boolean run = false;
        int caseSwitch;
        string titel = string.Empty;
        string content = string.Empty;
        int blogId;
        string url = string.Empty;
        string input = string.Empty;
        string error = "Error";

        public static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            while (run)
            {
                Console.WriteLine("Entity Framework");
                Console.WriteLine("------------------------");
                Console.WriteLine("1. Insert Blog");
                Console.WriteLine("2. Insert Post");
                Console.WriteLine("2. Delete Blog");
                if (int.TryParse(Console.ReadLine(), out caseSwitch) && caseSwitch <= 3 && caseSwitch != 0)
                {
                    Console.Clear();
                }
                switch (caseSwitch)
                {
                    case 1:
                        Program AddBlog = new Program();
                        AddBlog.AddBlog();
                        break;
                    case 2:
                        Program AddPost = new Program();
                        AddPost.AddPost();
                        break;
                    case 3:
                        Program DeleteBlog = new Program();
                        DeleteBlog.DeleteBlog();
                        break;
                    default:
                        Console.WriteLine($"{error} wrong input!");
                        break;
                }
            }
        }

        public void AddBlog()
        {
            //Add Blog
            using (var db = new BloggingContext())
            {
                Console.WriteLine("Blog URL: ");
                url = Console.ReadLine();
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
        }

        public void AddPost()
        {
            //Add Post
            using (var db = new BloggingContext())
            {
                Console.WriteLine("Titel: ");
                titel = Console.ReadLine();
                Console.WriteLine("Content: ");
                content = Console.ReadLine();
                Console.WriteLine("BlogId: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out blogId))
                {
                    Console.WriteLine($"{error} wrong ID!");
                }
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
        }

        public void DeleteBlog()
        {
            //Remove Blog with BlogId
            Console.WriteLine("BlogId: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out blogId))
            {
                Console.WriteLine($"{error} wrong ID!");
            }
            var removeUrl = new Blog() { BlogId = blogId};
            using (var context = new BloggingContext())
            {
                context.Blogs.Attach(removeUrl);
                context.Blogs.Remove(removeUrl);
                context.SaveChanges();
            }
        }

        //TODO DeletePost
        public void DeletePost()
        {
            //Remove Post with PostId
            var removePost = new Post() { PostId = id };
            using (var context = new BloggingContext())
            {
                context.Blogs.Attach(removePost);
                context.Blogs.Remove(removePost);
                context.SaveChanges();
            }
        }
    }
}