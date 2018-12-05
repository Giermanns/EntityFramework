using System;
using System.Linq;

namespace ConsoleApp.NewDb
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean run = false;
            int caseSwitch = 0;
            int id = 0;

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
            }

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
            var url = new Blog() { BlogId = id };
            using (var context = new BloggingContext())
            {
                context.Entry(url).State = System.Data.Entety;
                context.SaveChanges();
            }
        }
    }
}