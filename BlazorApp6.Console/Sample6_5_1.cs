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
    public class Sample6_5_1
    {
        public static void Run()
        {
            WriteLine("\n");
            WriteLine("6.5.1 データの更新方法");

            using (PubsDbContext context = new PubsDbContext())
            {
                WriteLine("\n" + "基本的なデータ更新の書き方例");

                var authorsInCA = context.Authors.Where(a => a.State == "CA");
                foreach (var a in authorsInCA) a.Contract = !a.Contract;
                try {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    WriteLine("楽観同時実行制御違反が発生しました: " + ex.Message);
                }
            }

            using (PubsDbContext context = new PubsDbContext())
            {
                WriteLine("\n" + "更新・削除・追加の実装例");

                var a1 = context.Authors.FirstOrDefault(a => a.AuthorId == "172-32-1176");
                if (a1 != null)
                {
                    a1.AuthorFirstName = "UpdatedFirstName";
                    a1.AuthorLastName = "UpdatedLastName";
                }

                var a2 = context.Authors.FirstOrDefault(a => a.AuthorId == "341-22-1782");
                if (a2 != null)
                {
                    context.Authors.Remove(a2);
                }

                var a3 = context.Authors.FirstOrDefault(a => a.AuthorId == "999-99-9999");
                if (a3 == null)
                {
                    a3 = new Author
                    {
                        AuthorId = "999-99-9999",
                        AuthorFirstName = "New",
                        AuthorLastName = "Author",
                        State = "NY",
                        Phone = "123-456-7890",
                        Contract = true
                    };
                    context.Authors.Add(a3);
                };

                try {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    WriteLine("楽観同時実行制御違反が発生しました: " + ex.Message);
                }
            }
            // 確認用SQL：
            // SELECT * FROM [pubs].[dbo].[authors] Where [au_id] IN ('172-32-1176','341-22-1782', '999-99-9999')

            WriteLine("\n" + "別コンテキスト内でのアタッチ処理の例");

            Author? author;

            using (PubsDbContext context1 = new PubsDbContext())
            {
                author = context1.Authors.FirstOrDefault(a => a.AuthorId == "172-32-1176");
            }

            if (author != null)
            {
                author.AuthorFirstName = "FirstNameUpdated";
                author.AuthorLastName = "LastNameUpdated";
            }

            using (PubsDbContext context2 = new PubsDbContext())
            {
                context2.Entry(author!).State = EntityState.Modified;
                try {
                    context2.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    WriteLine("楽観同時実行制御違反が発生しました: " + ex.Message);
                }
            }
            // 確認用SQL：
            // SELECT * FROM [pubs].[dbo].[authors] Where [au_id] = '172-32-1176'
        }
    }
}