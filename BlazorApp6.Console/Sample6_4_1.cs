using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp6.Data;
using BlazorApp6.Models;
using static System.Console;

namespace BlazorApp6.Console
{
    public class Sample6_4_1
    {
        public static void Run()
        {
            WriteLine("\n");
            WriteLine("6.4.1 データ参照方法");

            using (PubsDbContext context = new PubsDbContext())
            {
                WriteLine("\n" + "n 件データ取得");

                var query1 = from a in context.Authors where a.State == "CA" select a;
                List<Author> authors = query1.ToList();

                foreach (var author in authors)
                {
                    WriteLine("{0}: {1}, {2}", author.AuthorId, author.AuthorLastName, author.AuthorFirstName);
                }

                WriteLine("\n" + "1 件データ取得");

                var query2 = from a in context.Authors where a.AuthorId == "172-32-1176" select a;
                Author? authors2 = query2.FirstOrDefault();

                if (authors2 != null)
                {
                    WriteLine("{0}: {1}, {2}", authors2.AuthorId, authors2.AuthorLastName, authors2.AuthorFirstName);
                }
            }
        }
    }
}