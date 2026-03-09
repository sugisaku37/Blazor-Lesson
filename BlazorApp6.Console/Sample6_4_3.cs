using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp6.Data;
using BlazorApp6.Models;
using static System.Console;

namespace BlazorApp6.Console
{
    public class Sample6_4_3
    {
        public static void Run()
        {
            WriteLine("\n");
            WriteLine("6.4.3 変形・加工処理（射影処理）");

            using (PubsDbContext context = new PubsDbContext())
            {
                var query = from a in context.Authors
                             where a.State == "CA"
                             select new AuthorOverview
                             {
                                 AuthorId = a.AuthorId,
                                 AuthorName = a.AuthorLastName + " " + a.AuthorFirstName,
                                 Phone = a.Phone,
                                 State = a.State ?? string.Empty
                             };
                List<AuthorOverview> authors = query.ToList();

                foreach (var author in authors)
                {
                    WriteLine("{0}: {1}, {2}, {3}", author.AuthorId, author.AuthorName, author.Phone, author.State);
                }
            }
        }
    }
}