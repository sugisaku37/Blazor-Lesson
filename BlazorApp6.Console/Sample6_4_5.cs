using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp6.Data;
using BlazorApp6.Models;
using static System.Console;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp6.Console
{
    public class Sample6_4_5
    {
        public static void Run()
        {
            WriteLine("\n");
            WriteLine("6.4.5 リレーションシップの手繰り方");

            using (PubsDbContext context = new PubsDbContext())
            {
                WriteLine("\n" + "LINQクエリで集計データを取得する実装例");

                var query = context.Stores.Select(st => new
                {
                    st.StoreId,
                    st.StoreName,
                    TotalSales = st.Sales.Sum(sl => sl.Title.Price * sl.Quantity)
                });
                var stores = query.ToList();

                foreach (var store in stores)
                {
                    WriteLine(store);
                }
            }

            using (PubsDbContext context = new PubsDbContext())
            {
                WriteLine("\n" + "クエリに含まれておらず、データを参照できない例");

                var query = from t in context.Titles
                            where t.Price > 3.0M
                            select t;

                foreach (var title in query.ToList())
                {
                    WriteLine("{0}: {1}, {2}", title.TitleId, title.TitleName, title.Publisher?.PublisherName ?? "N/A");
                    foreach (var ta in title.TitleAuthors)
                    {
                        WriteLine("\t  {0}", ta.Author.AuthorLastName + " " + ta.Author.AuthorFirstName);
                    }
                }
            }

            using (PubsDbContext context = new PubsDbContext())
            {
                WriteLine("\n" + "一括読み込み機能の実装例");

                var query = from t in context.Titles.Include(t => t.Publisher)
                                                    .Include(t => t.TitleAuthors).ThenInclude(ta => ta.Author)
                            where t.Price > 3.0M
                            select t;

                foreach (var title in query.ToList())
                {
                    WriteLine("{0}: {1}, {2}", title.TitleId, title.TitleName, title.Publisher?.PublisherName ?? "N/A");
                    foreach (var ta in title.TitleAuthors)
                    {
                        WriteLine("\t  {0}", ta.Author.AuthorLastName + " " + ta.Author.AuthorFirstName);
                    }
                }
            }

            using (PubsDbContext context = new PubsDbContext())
            {
                WriteLine("\n" + "明示的読み込み機能の実装例");

                var query = from t in context.Titles
                            where t.Price > 3.0M
                            select t;

                foreach (var title in query.ToList())
                {
                    context.Entry(title).Reference(t => t.Publisher).Load();
                    context.Entry(title).Collection(t => t.TitleAuthors).Load();
                    WriteLine("{0}: {1}, {2}", title.TitleId, title.TitleName, title.Publisher?.PublisherName ?? "N/A");
                    foreach (var ta in title.TitleAuthors)
                    {
                        context.Entry(ta).Reference(ta => ta.Author).Load();
                        WriteLine("\t  {0}", ta.Author.AuthorLastName + " " + ta.Author.AuthorFirstName);
                    }
                }
            }
        }
    }
}